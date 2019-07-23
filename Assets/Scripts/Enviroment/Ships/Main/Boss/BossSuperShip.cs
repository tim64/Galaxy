using static Constants;
using UnityEngine;

public class BossSuperShip : BaseShip
{
	private Vector3 startPos;

	private readonly float speed = BOSS_SPEED;
	private readonly float xScale = BOSS_X_PATH_SCALE;
	private readonly float yScale = BOSS_Y_PATH_SCALE;

	public bool attackPhase;
	private float tweenTime;

	private Vector3 upVector;
	private Vector3 rightVector;

	private void Awake()
	{
		hp = BOSS_HP;
		shootRate = BOSS_SHOOT_RATE;
		damage = BOSS_DAMAGE;
		shootForce = BOSS_SHOOT_FORCE;

		useRandomShootRange = false;
	}

	/// <summary>
	/// Переопределенный метод старта
	/// </summary>
	public override void Start()
	{
		startPos = transform.position;
		base.Start();
	}

	/// <summary>
	/// Переопределенный метод BaseShip для стрельбы
	/// </summary>
	public override void Shoot()
	{
		if (attackPhase)
		{
			base.Shoot();
		}
	}

	/// <summary>
	/// Метод начинает атаку босса на игрока и он активирует все свои компоненты
	/// После активации босс перестает быть неуязвимым
	/// </summary>
	public virtual void StartAttackPhase()
	{
		startPos = transform.position;
		attackPhase = true;
		RemoveInvulnerability();
		ActivateGuns();	
	}

	private void RemoveInvulnerability()
	{
		GetComponent<Collider2D>().enabled = true;
	}

	private void ActivateGuns()
	{
		foreach (var item in GetComponentsInChildren<BossGun>())
		{
			item.GetComponent<BossGun>().enabled = true;
			item.GetComponent<Collider2D>().enabled = true;
		}
	}

	void Update()
	{
		if (attackPhase)
		{
			tweenTime += Time.deltaTime;
			Vector3 upVector = Vector3.up * Mathf.Sin(tweenTime * speed);
			Vector3 rightVector = Vector3.right * Mathf.Sin(tweenTime / 2 * speed);
			transform.position = startPos + (rightVector * xScale) - (upVector * yScale);
		}
	}

	protected override void DestroyShip()
	{
		base.DestroyShip();

		//Конец игры
		//Конец игры
		LeanTween.delayedCall(END_GAME_PAUSE_TIME, () => UIController.instance.EndGame(true));
	}
}
