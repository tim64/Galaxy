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
	private Rigidbody2D rb;
	private Vector2 playerPos;

	private int direction;

	public PlayerButton LeftButton; 
	public PlayerButton RightButton;

	[HideInInspector]
	public UnityEvent damageEvent;

	[HideInInspector]
	public float lastDamage;

	[HideInInspector]
	public float Hp { get; private set; } = PLAYER_MAX_HP;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();

		if (damageEvent == null)
		{
			damageEvent = new UnityEvent();
		}
	}


	private void Start() => playerPos = transform.position;

	private void FixedUpdate()
    {
		Vector2 velocity = Vector2.zero;

		if (Input.GetKeyDown(KeyCode.Space) && !isShooting)
		{
			Attack();
		}

		//if (RightButton.IsPressed)
		//{
		//	Debug.Log("Press Right");
		//	direction = 1;
		//	Move();
		//}

		//if (LeftButton.IsPressed)
		//{
		//	Debug.Log("Press Left");
		//	direction = -1;
		//	Move();
		//}

		if (RightButton.IsPressed) velocity.x += speed;
		if (LeftButton.IsPressed) velocity.x -= speed;

		rb.velocity = velocity * Time.fixedDeltaTime;
		//Debug.Log(rb.position.x);
		rb.position = new Vector3(Mathf.Clamp(rb.position.x, -PLAYER_MAX_X_POSITION, PLAYER_MAX_X_POSITION), rb.position.y, 0f);
	}

	//private void Move()
	//{
	//	float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed * direction);
	//	playerPos = new Vector3(Mathf.Clamp(xPos, -PLAYER_MAX_X_POSITION, PLAYER_MAX_X_POSITION), playerPos.y, 0f);
	//	transform.position = playerPos;
	//}

	public void Attack()
	{
		isShooting = true;

		PoolObject bullet = PoolManager.Get(POOL_PLAYER_BULLET_ID);
		bullet.GetComponent<Bullet>().damage = damage;
		bullet.transform.position = transform.position;
		bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * shootForce);

		AudioManager.PlaySoundOnce("PlayerBullet");
		LeanTween.delayedCall(reloadingTime, () => isShooting = false);
	}

	public void Damage(float damage)
	{
		lastDamage = damage;
		damageEvent.Invoke();
		Hp -= damage;

		AudioManager.PlaySoundOnce("Damage");

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
		gameObject.SetActive(false);

		AudioManager.PlaySoundOnce("BossBoom");

		//Конец игры
		LeanTween.delayedCall(END_GAME_PAUSE_TIME, () => UIController.instance.EndGame(false));
	}
}