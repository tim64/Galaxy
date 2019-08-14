using UnityEngine;


/// <summary>
/// Класс, генерирует случайные корабли на игровой сцене
/// Данные берет из объекта Level
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
		currentLevelData = Level.CreateFromJSON(LevelController.currentLevelIndex);
		//Показываем название уровня
		UIController.instance.ShowIntroText();
		//Включаем музыкальную тему
		MusicController.LoadMusic(currentLevelData.LevelName);

		shipContainer = CreateShipContainer();

		//shipContainer.transform.localPosition = WaypointController.instance.gameCenter.position;

		//Генерация кораблей
		GenerateShips();

		//Размещение кораблей по сетке
		ShipGridControl shipGrid = gameObject.AddComponent<ShipGridControl>();
		shipGrid.MoveShipsOnGrid(shipContainer);
		

		shipGrid.gridIsDone.AddListener(EndFleetGeneration);
	}

	private void EndFleetGeneration()
	{
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

	private GameObject CreateShipContainer()
    {
		GameObject ShipContainer = new GameObject
		{
			name = "ShipContainer"
		};

		ShipContainer.transform.parent = GameObject.Find("Enviroment").transform;
        return ShipContainer;
    }
}
