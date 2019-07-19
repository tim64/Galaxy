using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityNightPool;
using Random = UnityEngine.Random;

/// <summary>
/// Класс, перекрашивает корабли случайным цветом, используя смещение по каналам
/// Это реализуется с помощью нового матерала и шейдера HSLRangeShader
/// Параметры randomX, randomY, randomZ взяты исходя из лучшей цветовой совместимости
/// 
/// Это базовый класс для всех кораблей
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class BaseShip : MonoBehaviour, IMovable, IShootable
{
	public int bulletType;
	public float maxShootRate = 10;
	public GameObject explosionFX;
	public bool useRandomColor;

	//Полет корабля и атака игрока
	public bool attackState;
	public Transform target;

	//TODO вынести параметры в JSOM
	protected float rotateSpeed = 5;
	protected int shootForce = 4;
	protected int flySpeed = 6;
	protected int dmg = 3;

	protected bool useRandomShootRange = true;

	public UnityEvent respawnEvent;

	private void Awake()
    {
		if (useRandomColor)
		{
			ShipColorizer colorizer = GetComponentInChildren<ShipColorizer>();
			colorizer.RandomColorize(GetComponent<SpriteRenderer>());
			ModifiedParamsFromDifficult();
		}
    }

	private void ModifiedParamsFromDifficult()
	{
		rotateSpeed = 5 * World.newWorld.Difficulty;
		shootForce = 4 * World.newWorld.Difficulty;
		flySpeed = 6 * World.newWorld.Difficulty;
		dmg = 3 * World.newWorld.Difficulty;
		maxShootRate /= World.newWorld.Difficulty;
	}

	public virtual void Start()
	{
		StartCoroutine(Shooting());

		if (respawnEvent == null)
			respawnEvent = new UnityEvent();
	}

	private IEnumerator Shooting()
	{
		while (true)
		{
			if (useRandomShootRange)
			{
				yield return new WaitForSeconds(Random.Range(1, maxShootRate));
				Shoot();
			}
			else
			{
				yield return new WaitForSeconds(maxShootRate);
				Shoot();
			}
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
		float dist = flySpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, dist);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			attackState = false;
			collision.gameObject.GetComponent<Player>().Damage(20);
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
		Vector2 relativePos = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);
		rotation.x = rotation.y = 0.0f;
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
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
		PoolObject bullet = PoolManager.Get(bulletType);
		Bullet bulletParams = bullet.GetComponent<Bullet>();
		Transform bulletTransform = bullet.transform;
		Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

		bulletTransform.rotation = transform.rotation;
		bulletTransform.position = transform.position;


		if (target != null)
		{
			var playereDir = target.position - transform.position;
			playereDir = playereDir.normalized;
			bulletRb.AddForce(playereDir * shootForce);
		}
		else
		{
			bulletRb.AddForce(-transform.up * shootForce);
		}

		bulletParams.dmg = dmg;

		bulletParams.Shoot();
	}

	public virtual void DestroyShip()
	{
		//PoolObject fx = PoolManager.Get(7);
		//fx.transform.position = transform.position;
		Destroy(gameObject);
	}
}
