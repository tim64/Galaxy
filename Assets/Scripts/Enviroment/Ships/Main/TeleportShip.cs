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
			yield return new WaitForSeconds(TELEPORT_SHIP_JUMP_PERIOD + Random.Range(0, TELEPORT_RANDOM_MAX));
			PoolObject fx = PoolManager.Get(POOL_TELEPORT_FX_ID);
			fx.transform.position = transform.position;

			LeanTween.delayedCall(TELEPORT_FX_DELAY, TeleportShipAction);
			
		}
	}

	private void TeleportShipAction()
	{
		if (transform != null)
		{
			AudioManager.PlaySoundOnce("Teleport");
			transform.position = Random.insideUnitCircle * TELEPORT_SHIP_RADIUS;
			PoolObject fx = PoolManager.Get(POOL_TELEPORT_FX_ID);
			fx.transform.position = transform.position;
		}
	}
}
