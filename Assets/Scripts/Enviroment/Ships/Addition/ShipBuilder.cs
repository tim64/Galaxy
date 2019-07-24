using UnityEngine;
using UnityNightPool;
using static Constants;

/// <summary>
/// Класс который инстантиирует объекты-корабли по заданным условиям.
/// В данный момент не оптимизирован под пул объектов
/// </summary>
public class ShipBuilder : MonoBehaviour
{
	[Space]

	[Header("Префабы кораблей")]
	public GameObject[] shipPrefabs;

	[Space]

	[Header("Префабы боссов")]
	public GameObject[] bossShipPrefabs;

	/// <summary>
	/// Метод строит случайный корабль и заданного массива префабов
	/// </summary>
	/// <returns></returns>
	public GameObject BuildRandomShip()
	{
		GameObject newShip = Instantiate(shipPrefabs[Random.Range(0, shipPrefabs.Length)]);
		newShip.GetComponent<BaseShip>().useRandomColor = true;
		return newShip;
	}

	public GameObject CreateBossShip()
	{
		//FIXME: Индекс из массива боссов
		GameObject newShip = Instantiate(bossShipPrefabs[Level.currentLevelData.BossType]);
		newShip.GetComponent<BaseShip>().useRandomColor = true;
		newShip.GetComponent<BaseShip>().Activate();
		return newShip;
	}


}
