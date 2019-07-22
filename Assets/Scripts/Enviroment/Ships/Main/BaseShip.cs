using System;
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
	public bool useRandomColor;
	public UnityEvent respawnEvent;

	[Header("FX")]
	public GameObject explosionFX;


	//Полет корабля и атака игрока
	[HideInInspector]
	public bool attackState;
	[HideInInspector]
	public Transform target;

	//Параметры корабля
	protected float hp = BASE_SHIP_HP;
	protected float shootRate = BASE_SHIP_SHOOT_RATE;
	protected float rotateSpeed = BASE_SHIP_ROTATE_SPEED;
	protected float shootForce = BASE_SHIP_SHOOT_FORCE;
	protected float flySpeed = BASE_SHIP_FLY_SPEED;
	protected float damage = BASE_SHIP_DAMAGE;

	protected bool useRandomShootRange = true;

	private void Awake()
    {
		if (useRandomColor)
		{
			ShipColorizer colorizer = GetComponentInChildren<ShipColorizer>();
			colorizer.RandomColorize(GetComponent<SpriteRenderer>());
		}

		ModifiyParamsFromDifficulty();
	}

	private void ModifiyParamsFromDifficulty()
	{
		float difficulty = Level.newWorld.Difficulty;

		rotateSpeed = BASE_SHIP_ROTATE_SPEED * difficulty;
		shootForce = BASE_SHIP_SHOOT_FORCE * difficulty;
		flySpeed = BASE_SHIP_FLY_SPEED * difficulty;
		damage = BASE_SHIP_DAMAGE * difficulty;
		shootRate *= difficulty;
	}

	public virtual void Start()
	{
		StartCoroutine(Shooting());

		if (respawnEvent == null)
		{
			respawnEvent = new UnityEvent();
		}

	}

	private IEnumerator Shooting()
	{
		while (true)
		{
			var waitTime = useRandomShootRange ? Random.Range(0, SHOOT_RATE_MAX / shootRate) : SHOOT_RATE_MAX / shootRate;
			yield return new WaitForSeconds(waitTime);
			Shoot();
		}
	}

	private void Update()
	{
		if (attackState)
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
			respawnEvent.Invoke();
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

	public virtual void DamageShip(float damage)
	{
		if ((hp -= damage) <= 0)
		{
			DestroyShip();
		}
	}


	protected virtual void DestroyShip()
	{
		PoolObject fx = PoolManager.Get(POOL_EXPLOSION_ID);
		fx.transform.position = transform.position;
		Destroy(gameObject);
	}
}
