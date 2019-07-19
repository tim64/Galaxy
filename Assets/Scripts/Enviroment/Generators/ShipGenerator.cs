using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
/// Класс, генерирует случайные корабли на игровой сцене
/// Данные берет из объекта World
/// </summary>
public class ShipGenerator : MonoBehaviour
{
	//Префаб базового корабля
	public BaseShip shipBasePrefab;

	//Билдер кораблей на сцене
	public ShipBuilder builder;

	//Точка ориентации для флота
	public Transform centerGame;

	private World currentWorld;
	private GameObject shipContainer;


	private void Start()
	{
		//Получаем параметры уровня из JSON
		currentWorld = GetCurrentWorld(Constants.JSON_PATH_WORLD1);
		Debug.Log(currentWorld.WorldName);
		shipContainer = CreateShipContainer();

		GenerateShips();

		//Размещение кораблей по сетке
		ShipGridMover ShipMover = new ShipGridMover();
		ShipMover.MoveShipsOnGrid(shipContainer);

		shipContainer.transform.localPosition = centerGame.position;

		//Добавление перемещения кораблей
		shipContainer.AddComponent<ShipMovement>();

		//Добавление скрипта управления кораблями
		shipContainer.AddComponent<FleetControl>();
		shipContainer.GetComponent<FleetControl>().builder = builder;
	}

	private void GenerateShips()
	{
		int worldShipCount = currentWorld.ShipCount;
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

	private World GetCurrentWorld(string JSONString)
    {
        World newWorld = World.CreateFromJSON(JSONString);
        return newWorld;
    }
}
