using System;
using System.Collections.Generic;
using UnityEngine;
using static Constants;
using Random = UnityEngine.Random;


/// <summary>
/// Класс, генерирует случайные корабли на игровой сцене
/// Данные берет из объекта World
/// </summary>
public class ShipGenerator : MonoBehaviour
{
	//Билдер кораблей на сцене
	public ShipBuilder builder;

	private Level currentLevelData;
	private GameObject shipContainer;


	private void Start()
	{
		//Получаем параметры уровня из JSON
		currentLevelData = Level.CreateFromJSON(JSON_PATH_LEVEL + LevelController.currentLevelIndex);

		shipContainer = CreateShipContainer();

		GenerateShips();

		//Размещение кораблей по сетке
		//ShipGridMover ShipMover = new ShipGridMover();
		ShipGridMover ShipMover = gameObject.AddComponent<ShipGridMover>();
		ShipMover.MoveShipsOnGrid(shipContainer);

		shipContainer.transform.localPosition = WaypointController.instance.gameCenter.position;

		//Добавление перемещения кораблей
		shipContainer.AddComponent<ShipMovement>();

		//Добавление скрипта управления кораблями
		shipContainer.AddComponent<FleetController>();
		shipContainer.GetComponent<FleetController>().builder = builder;
	}

	private void GenerateShips()
	{
		int worldShipCount = currentLevelData.ShipCount;
		for (int i = 0; i < worldShipCount; i++)
		{
			CreateRandomShip();
		}
	}

	private void CreateRandomShip()
	{
		GameObject newShip = builder.BuildRandomShip();
		newShip.transform.parent = shipContainer.transform;
	}

    private static GameObject CreateShipContainer()
    {
		GameObject ShipContainer = new GameObject
		{
			name = "ShipContainer"
		};

		ShipContainer.transform.parent = GameObject.Find("Enviroment").transform;
        return ShipContainer;
    }
}
