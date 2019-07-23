using System.Collections;
using UnityEngine;
using UnityNightPool;
using static Constants;

/// <summary>
/// Корабли-телепорты
/// Иногда могут телепортироваться в другую точку пространства.
/// </summary>
public class TeleportShip : BaseShip
{
	public override void Start()
	{
		base.Start();
		StartCoroutine(Teleport());
	}

	private IEnumerator Teleport()
	{
		while (true && !attackState)
		{
			//Добавляем случайное значение, чтобы было разнообразие в поведении кораблей
			yield return new WaitForSeconds(TELEPORT_SHIP_JUMP_PERIOD + Random.Range(-1, 2));
			PoolObject fx = PoolManager.Get(POOL_TELEPORT_FX_ID);
			fx.transform.position = transform.position;

			LeanTween.delayedCall(0.5f, TeleportShipAction);
			
		}
	}

	private void TeleportShipAction()
	{
		if (transform != null)
		{
			transform.position = Random.insideUnitCircle * TELEPORT_SHIP_RADIUS;
			PoolObject fx = PoolManager.Get(POOL_TELEPORT_FX_ID);
			fx.transform.position = transform.position;
		}
	}
}
