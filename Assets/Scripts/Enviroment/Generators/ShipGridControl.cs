using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityNightPool;
using static Constants;

/// <summary>
/// Класс, который расставляет корабли по сетке
/// </summary>
/// <param name="ShipContainer"></param>
public class ShipGridControl : MonoBehaviour
{
	private int hPos;
	private int vPos;

	public UnityEvent gridIsDone;

	private void Awake()
	{
		if (gridIsDone == null)
		{
			gridIsDone = new UnityEvent();
		}
	}


	/// <summary>
	/// Метод, который расставляет корабли по сетке
	/// Основной метод класса
	/// </summary>
	/// <param name="shipContainer"></param>
	public void MoveShipsOnGrid(GameObject shipContainer)
	{
		int shipCount = shipContainer.transform.childCount;
		int maxSideSize = Mathf.FloorToInt(Mathf.Sqrt(shipCount)) + FLEET_HORIZONTAL_INDEX;

		StartCoroutine(ShipMover(maxSideSize, shipContainer));
	}

	private IEnumerator ShipMover(int maxSideSize, GameObject shipContainer)
	{
		//Выравниваем флот по оси Х
		float offsetX = (maxSideSize * GRID_SIZE)/2;

		//Делаем задержку для эффекта спавна корабля	
		WaitForSeconds wait = new WaitForSeconds(FLEET_SPAWN_ANIMATION_DELAY);
		BaseShip[] ships = shipContainer.GetComponentsInChildren<BaseShip>();

		foreach (var ship in ships)
		{
			ship.transform.position = new Vector2((hPos % maxSideSize * GRID_SIZE) - offsetX, vPos % maxSideSize * GRID_SIZE);

			hPos++;

			if (hPos >= maxSideSize)
			{
				vPos++;
				hPos = 0;
			}

			CreateSpawnFX(ship);
			yield return wait;
		}
		gridIsDone.Invoke();
	}

	private void CreateSpawnFX(BaseShip ship)
	{
		PoolObject fx = PoolManager.Get(POOL_TELEPORT_FX_ID);
		fx.transform.position = ship.transform.position;
		LeanTween.delayedCall(FLEET_SPAWN_ANIMATION_DELAY, ship.Activate);
	}
}
