﻿using System.Collections;
using UnityEngine;
using UnityNightPool;
using static Constants;

public class BossMegaShip : BossSuperShip
{
	private void Awake()
	{
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
		StartCoroutine(SpawnShip());

	}

	private IEnumerator SpawnShip()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			PoolObject shipObject = PoolManager.Get(9);
			shipObject.transform.position = transform.position;
			BaseShip ship = shipObject.GetComponent<BaseShip>();
			ship.target = WaypointController.instance.attakPoint;
			ship.attackState = true;
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
}
