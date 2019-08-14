﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityNightPool;
using Random = UnityEngine.Random;
using static Constants;
/// <summary>
/// Класс, перекрашивает корабли случайным цветом, используя смещение по каналам
/// Это реализуется с помощью нового матерала и шейдера HSLRangeShader
/// Параметры randomX, randomY, randomZ взяты исходя из лучшей цветовой совместимости
/// 
/// Это базовый класс для всех кораблей
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class BaseShip : MonoBehaviour
{
	[Header("FX")]
	public GameObject explosionFX;

	//Полет корабля и атака игрока
	[HideInInspector]
	public bool attackState;
	[HideInInspector]
	public Transform target;
	public bool useRandomColor;

	//Параметры корабля
	protected float hp = BASE_SHIP_HP;
	protected float shootRate = BASE_SHIP_SHOOT_RATE;
	protected float rotateSpeed = BASE_SHIP_ROTATE_SPEED;
	protected float shootForce = BASE_SHIP_SHOOT_FORCE;
	protected float flySpeed = BASE_SHIP_FLY_SPEED;
	protected float damage = BASE_SHIP_DAMAGE;

	protected bool useRandomShootRange = true;
	protected bool isActivated = false;
	protected bool shootImmediately = false;

	protected virtual void Awake()
    {
		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<Collider2D>().enabled = false;

		if (useRandomColor)
		{
			ShipColorizer colorizer = GetComponentInChildren<ShipColorizer>();
			colorizer.RandomColorize(GetComponent<SpriteRenderer>());
		}

		ModifiyParamsFromDifficulty();
	}

	private void ModifiyParamsFromDifficulty()
	{
		float difficulty = Level.currentLevelData.Difficulty;

		rotateSpeed = BASE_SHIP_ROTATE_SPEED * difficulty;
		shootForce = BASE_SHIP_SHOOT_FORCE * difficulty;
		flySpeed = BASE_SHIP_FLY_SPEED * difficulty;
		damage = BASE_SHIP_DAMAGE * difficulty;
		shootRate *= difficulty;
	}

	/// <summary>
	/// Метод старта
	/// </summary>
	public virtual void Start()
	{

	}

	/// <summary>
	/// Активация корабля и начало стрельбы
	/// </summary>
	public virtual void Activate()
	{
		AudioManager.PlaySoundOnce(S_TELEPORT);
		isActivated = true;
		GetComponent<SpriteRenderer>().enabled = isActivated;
		GetComponent<Collider2D>().enabled = isActivated;
		StartCoroutine(Shooting());
	}

	/// <summary>
	/// Метод стрельбы у корабля
	/// </summary>
	/// <returns></returns>
	protected IEnumerator Shooting()
	{
		while (true && isActivated)
		{
			if (shootImmediately)  Shoot();
			var waitTime = useRandomShootRange ? Random.Range(0, SHOOT_RATE_MAX / shootRate) : SHOOT_RATE_MAX / shootRate;
			yield return new WaitForSeconds(waitTime);
			if (!shootImmediately) Shoot();
		}
	}

	private void Update()
	{
		if (attackState && isActivated)
		{
			Move();
			Rotate();
		}
	}

	/// <summary>
	/// Метод, который определяет поведение корабля при его движении
	/// Базовое поведение - приследование и обстрел
	/// </summary>
	public virtual void Move()
	{
		if (target != null)
		{
			float dist = flySpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target.position, dist);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			attackState = false;
			collision.gameObject.GetComponent<Player>().Damage(BASE_SHIP_CRUSH_DAMAGE);
			DestroyShip();
		}

		if (collision.gameObject.tag == "Respawn")
		{
			attackState = false;
			DestroyShip();
		}
	}

	private void Rotate()
	{
		if (target != null)
		{
			Vector2 relativePos = target.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
			rotation.x = rotation.y = 0.0f;
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
		}
	}

	/// <summary>
	/// Метод, который вызывает атаку на игрока
	/// </summary>
	/// <param name="newTarget"></param>
	public void Attack(Transform newTarget)
	{
		//Отсоединяем корабль от флота, чтобы движение слота не влияло на корабль
		if (gameObject != null)
		{
			transform.parent = null;
		}

		AudioManager.PlaySoundOnce(S_FLY);

		target = newTarget;
		attackState = true;
	}

	/// <summary>
	/// Метод, который определяет поведение корабля при его стрельбе
	/// </summary>
	public virtual void Shoot()
	{
		PoolObject bulletObject = PoolManager.Get(POOL_BULLET_ID);
		Bullet bullet = bulletObject.GetComponent<Bullet>();
		Transform bulletTransform = bulletObject.transform;
		Rigidbody2D bulletRb = bulletObject.GetComponent<Rigidbody2D>();

		bulletTransform.rotation = transform.rotation;
		bulletTransform.position = transform.position;

		AudioManager.PlaySoundOnce(S_ENEMY_BULLET);


		if (target != null)
		{
			Vector3 playerDirection = target.position - transform.position;
			playerDirection = playerDirection.normalized;
			bulletRb.AddForce(playerDirection * shootForce);
		}
		else
		{
			bulletRb.AddForce(-transform.up * shootForce);
		}

		bullet.damage = damage;
	}

	/// <summary>
	/// Метод для нанесения урона корабля
	/// </summary>
	/// <param name="damage"></param>
	public virtual void DamageShip(float damage)
	{
		if ((hp -= damage) <= 0)
		{
			AudioManager.PlaySoundOnce(S_DAMAGE);
			DestroyShip();
		}
	}

	/// <summary>
	/// Метод для уничтожения корабля
	/// </summary>
	protected virtual void DestroyShip()
	{
		PoolObject fx = PoolManager.Get(POOL_EXPLOSION_ID);
		fx.transform.position = transform.position;
		AudioManager.PlaySoundOnce(S_BASE_SHIP_BOOM);
		Destroy(gameObject);
	}
}
