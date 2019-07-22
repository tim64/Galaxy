using UnityEngine;
using UnityEngine.Events;
using UnityNightPool;
using static Constants;

public class Player : MonoBehaviour
{
	private readonly float speed = PLAYER_SPEED;
	private readonly float damage = PLAYER_DAMAGE;
	private readonly float reloadingTime = PLAYER_RELOADING_TIME;
	private readonly float shootForce = PLAYER_SHOOT_FORCE;
	private bool isShooting;
	private readonly Rigidbody2D rb;
	private Vector2 playerPos;

	[HideInInspector]
	public UnityEvent damageEvent;

	[HideInInspector]
	public float lastDamage;

	[HideInInspector]
	public float Hp { get; private set; } = PLAYER_MAX_HP;

	private void Awake()
	{
		if (damageEvent == null)
		{
			damageEvent = new UnityEvent();
		}
	}


	private void Start() => playerPos = transform.position;

	private void Update()
    {
		if (Input.GetMouseButton(0) || (Input.GetKeyDown(KeyCode.Space) && !isShooting))
        {
			isShooting = true;

			PoolObject bullet = PoolManager.Get(POOL_PLAYER_BULLET_ID);
			bullet.GetComponent<Bullet>().damage = damage;
			bullet.transform.position = transform.position;
			bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * shootForce);

			LeanTween.delayedCall(reloadingTime, () => isShooting = false);
        }

		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
		playerPos = new Vector3(Mathf.Clamp(xPos, -PLAYER_MAX_X_POSITION, PLAYER_MAX_X_POSITION), playerPos.y, 0f);
		transform.position = playerPos;
	}

	public void Damage(float damage)
	{
		lastDamage = damage;
		damageEvent.Invoke();
		Hp -= damage;

		if (Hp <= 0)
		{
			DestroyPlayer();
		}
	}

	public void DestroyPlayer()
	{
		PoolObject fx = PoolManager.Get(POOL_EXPLOSION_ID);
		fx.GetComponent<SpriteRenderer>().color = Color.yellow;
		fx.transform.position = transform.position;
		Destroy(gameObject);
	}
}