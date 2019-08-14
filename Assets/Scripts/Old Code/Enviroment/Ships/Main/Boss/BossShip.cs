﻿using static Constants;
using System.Collections;
using UnityEngine;

/// <summary>
/// Класс босса.
/// </summary>
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

	/// <summary>
	/// Пояление босса и начало его работы
	/// </summary>
	public override void Start()
	{
		startPos = transform.position;
		AudioManager.PlaySoundOnce(S_BOSS_ENGINE);
		base.Start();
	}

	/// <summary>
	/// Активация босса
	/// </summary>
	public override void Activate()
	{
		base.Activate();
	}

	/// <summary>
	/// Метод вызова cтрельбы
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

		StartCoroutine(HorizontalFly());
	}

	/// <summary>
	/// Снятие неуязвимости
	/// </summary>
	protected void RemoveInvulnerability()
	{
		GetComponent<Collider2D>().enabled = true;
	}

	/// <summary>
	/// Активация пушек босса
	/// </summary>
	protected void ActivateGuns()
	{
		foreach (var item in GetComponentsInChildren<BossGun>())
		{
			AudioManager.PlaySoundOnce(S_BOSS_ENGINE);
			item.enabled = true;
			item.Activate();
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

	/// <summary>
	/// Уничтожение босса
	/// </summary>
	protected override void DestroyShip()
	{
		base.DestroyShip();
		AudioManager.PlaySoundOnce(S_TELEPORT);
		//Конец игры
		LeanTween.delayedCall(END_GAME_PAUSE_TIME, () => UIController.instance.EndGame(true));
	}
}
