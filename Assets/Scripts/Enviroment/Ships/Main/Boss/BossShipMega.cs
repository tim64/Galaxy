using System.Collections;
using UnityEngine;
using UnityNightPool;
using static Constants;

public class BossShipMega : BossShip
{
	protected override void Awake()
	{
		base.Awake();
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
			yield return new WaitForSeconds(BOSS_JET_SPAWN_TIME);
			PoolObject shipObject = PoolManager.Get(POOL_BOSS_SHIP_ID);
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
