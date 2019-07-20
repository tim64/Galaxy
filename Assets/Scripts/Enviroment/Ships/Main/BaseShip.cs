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
	public int bulletType;
	public GameObject explosionFX;


	//Полет корабля и атака игрока
	[HideInInspector]
	public bool attackState;
	[HideInInspector]
	public Transform target;

	//Параметры корабля
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
			ModifiedParamsFromDifficult();
		}
    }

	private void ModifiedParamsFromDifficult()
	{
		rotateSpeed = BASE_SHIP_ROTATE_SPEED * World.newWorld.Difficulty;
		shootForce = BASE_SHIP_SHOOT_FORCE * World.newWorld.Difficulty;
		flySpeed = BASE_SHIP_FLY_SPEED * World.newWorld.Difficulty;
		damage = BASE_SHIP_DAMAGE * World.newWorld.Difficulty;
		shootRate *= World.newWorld.Difficulty;
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
			if (useRandomShootRange)
			{
				yield return new WaitForSeconds(Random.Range(0, SHOOT_RATE_MAX / shootRate));
				Shoot();
			}
			else
			{
				yield return new WaitForSeconds(shootRate);
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
			Vector3 playerDirection = target.position - transform.position;
			playerDirection = playerDirection.normalized;
			bulletRb.AddForce(playerDirection * shootForce);
		}
		else
		{
			bulletRb.AddForce(-transform.up * shootForce);
		}

		bulletParams.damage = damage;

		bulletParams.Shoot();
	}

	public virtual void DestroyShip()
	{
		PoolObject fx = PoolManager.Get(7);
		fx.transform.position = transform.position;
		Destroy(gameObject);
	}
}
