using System;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
/// Класс, который перемешивает корабли из сцены (из объекта ShipContainer) и расставляет их по сетке
/// Кроме того, класс делает именование объектов по порядку, для удобства
/// </summary>
/// <param name="ShipContainer"></param>
public class ShipGridMover : MonoBehaviour
{
	private readonly int gridSize = Constants.GRID_SIZE;
	private int hPos;
	private int vPos;

	//Параметр отвечает за рандомное строение флота кораблей (небольшое смещение по Х)
	private readonly bool useRandomFleetConfig;

	//Чем больше будет этот параметр, тем более горизонтально будут расположены корабли
	private readonly int horizontalIndex = Constants.FLEET_HORIZONTAL_INDEX;

	/// <summary>
	/// Метод, который перемешивает готовые корабли и расставляет их по сетке
	/// Основной метод класса
	/// </summary>
	/// <param name="shipContainer"></param>
	public void MoveShipsOnGrid(GameObject shipContainer)
	{
		int shipCount = shipContainer.transform.childCount;
		int maxSideSize = Mathf.FloorToInt(Mathf.Sqrt(shipCount)) + horizontalIndex;

		ShipRandomizer(shipCount, shipContainer.GetComponentsInChildren<BaseShip>());

		
		ShipMover(maxSideSize, shipContainer);

		if (useRandomFleetConfig)
		{
			OffsetFleetSquads(shipContainer);
		}

		#if UNITY_EDITOR
		//В релиз данный метод идти не должен
		RenameShips(shipContainer);
		#endif

	}

	private void OffsetFleetSquads(GameObject shipContainer)
	{
		Transform[] squads = shipContainer.GetComponentsInChildren<Transform>();
		foreach (var squad in squads)
		{
			if (squad.gameObject.tag == "Squad")
			{
				int randomOffset = Random.Range(1, 3);
				squad.transform.position += new Vector3(Random.Range(-randomOffset, randomOffset), squad.transform.localPosition.y, 0);
			}
		}
	}

	private void ShipMover(int maxSideSize, GameObject shipContainer)
	{

		BaseShip[] ships = shipContainer.GetComponentsInChildren<BaseShip>();

		//Создаем объект-отряд для добавления туда кораблей
		GameObject squad = CreateSquad(shipContainer);

		foreach (var ship in ships)
		{
			ship.transform.position = new Vector2(hPos % maxSideSize * gridSize, vPos % maxSideSize * gridSize);
			hPos++;

			//Добавляем корабль в отряд
			ship.transform.parent = squad.transform;

			if (hPos >= maxSideSize)
			{
				vPos++;
				hPos = 0;

				squad = CreateSquad(shipContainer);	
			}
		}

		Destroy(shipContainer.transform.GetChild(shipContainer.transform.childCount - 1).gameObject);
	}

	private GameObject CreateSquad(GameObject shipContainer)
	{
		GameObject shipRow = new GameObject();
		shipRow.transform.parent = shipContainer.transform;

		#if UNITY_EDITOR
		shipRow.name = "Squad" + (vPos + 1).ToString();
		#endif

		shipRow.gameObject.tag = "Squad";
		return shipRow;
	}

	private static void ShipRandomizer(int shipCount, BaseShip[] ships)
	{
		foreach (var ship in ships)
		{
			ship.transform.SetSiblingIndex(Random.Range(0, shipCount));
		}
	}

	private void RenameShips(GameObject shipContainer)
	{
		int index = 1;
		foreach (var ship in shipContainer.GetComponentsInChildren<BaseShip>())
		{
			ship.name = "Ship " + index.ToString();
			index += 1;
		}
	}

}
