using UnityEngine;
using static Constants;

/// <summary>
/// Класс, который перемешивает корабли из сцены (из объекта ShipContainer) и расставляет их по сетке
/// </summary>
/// <param name="ShipContainer"></param>
public class ShipGridMover : MonoBehaviour
{
	private int hPos;
	private int vPos;


	/// <summary>
	/// Метод, который перемешивает готовые корабли и расставляет их по сетке
	/// Основной метод класса
	/// </summary>
	/// <param name="shipContainer"></param>
	public void MoveShipsOnGrid(GameObject shipContainer)
	{
		int shipCount = shipContainer.transform.childCount;
		int maxSideSize = Mathf.FloorToInt(Mathf.Sqrt(shipCount)) + FLEET_HORIZONTAL_INDEX;

		ShipMover(maxSideSize, shipContainer);

	}

	private void ShipMover(int maxSideSize, GameObject shipContainer)
	{
		BaseShip[] ships = shipContainer.GetComponentsInChildren<BaseShip>();

		foreach (var ship in ships)
		{
			ship.transform.position = new Vector2(hPos % maxSideSize * GRID_SIZE, vPos % maxSideSize * GRID_SIZE);
			hPos++;

			if (hPos >= maxSideSize)
			{
				vPos++;
				hPos = 0;
			}
		}
	}
}
