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

	//Ссылки на кнопки управления
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

		if (RightButton.IsPressed) velocity.x += speed;
		if (LeftButton.IsPressed) velocity.x -= speed;

		rb.velocity = velocity * Time.fixedDeltaTime;
		rb.position = new Vector3(Mathf.Clamp(rb.position.x, -PLAYER_MAX_X_POSITION, PLAYER_MAX_X_POSITION), rb.position.y, 0f);
	}

	/// <summary>
	/// Метод для вызоыва атаки игрока
	/// </summary>
	public void Attack()
	{
		isShooting = true;

		PoolObject bullet = PoolManager.Get(POOL_PLAYER_BULLET_ID);
		bullet.GetComponent<Bullet>().damage = damage;
		bullet.transform.position = transform.position;
		bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * shootForce);

		AudioManager.PlaySoundOnce(S_PLAYER_BULLET);
		LeanTween.delayedCall(reloadingTime, () => isShooting = false);
	}

	/// <summary>
	/// Метод, для нанесения урона по игроку
	/// </summary>
	/// <param name="damage"></param>
	public void Damage(float damage)
	{
		lastDamage = damage;
		damageEvent.Invoke();
		Hp -= damage;

		AudioManager.PlaySoundOnce(S_DAMAGE);

		if (Hp <= 0)
		{
			DestroyPlayer();
		}
	}

	/// <summary>
	/// Метод для уничтожения игрока
	/// </summary>
	public void DestroyPlayer()
	{
		PoolObject fx = PoolManager.Get(POOL_EXPLOSION_ID);
		fx.GetComponent<SpriteRenderer>().color = Color.yellow;
		fx.transform.position = transform.position;
		gameObject.SetActive(false);

		AudioManager.PlaySoundOnce(S_PLAYER_BULLET);

		//Конец игры
		LeanTween.delayedCall(END_GAME_PAUSE_TIME, () => UIController.instance.EndGame(false));
	}
}