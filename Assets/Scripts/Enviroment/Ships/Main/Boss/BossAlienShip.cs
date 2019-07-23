using System.Collections;
using UnityEngine;
using static Constants;

public class BossAlienShip : BossSuperShip
{
	private void Awake()
	{
		hp = BOSS_HP;
		shootRate = BOSS_SHOOT_RATE;
		damage = BOSS_DAMAGE;
		shootForce = BOSS_SHOOT_FORCE;

		useRandomShootRange = false;
	}

	/// <summary>
	/// Метод начинает атаку босса на игрока и он активирует все свои компоненты
	/// После активации босс перестает быть неуязвимым
	/// </summary>
	public override void StartAttackPhase()
	{
		base.StartAttackPhase();
		StartCoroutine(HorizontalFly());

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

	void Update()
	{

	}
}
