using static Constants;
using System.Collections;
using UnityEngine;

public class BossShip : BaseShip
{
	protected Vector3 startPos;
	public bool attackPhase;

	protected virtual new void Awake()
	{
		hp = BOSS_HP;
		shootRate = BOSS_SHOOT_RATE;
		damage = BOSS_DAMAGE;
		shootForce = BOSS_SHOOT_FORCE;

		useRandomShootRange = false;
	}


	public override void Start()
	{
		startPos = transform.position;
		base.Start();
	}

	public override void Activate()
	{
		base.Activate();
	}

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

		StartCoroutine(HorizontalFly());
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

	private IEnumerator HorizontalFly()
	{
		while (true)
		{
			LeanTween.moveLocalX(gameObject, -BOSS_HORIZONTAL_MAX_X, BOSS_HORIZONTAL_FLY_TIME).setOnComplete(() => LeanTween.moveLocalX(
				gameObject,
				BOSS_HORIZONTAL_MAX_X,
				BOSS_HORIZONTAL_FLY_TIME * 2));

			yield return new WaitForSeconds(BOSS_HORIZONTAL_FLY_PERIOD);
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
