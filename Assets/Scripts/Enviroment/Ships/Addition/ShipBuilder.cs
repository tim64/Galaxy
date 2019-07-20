using UnityEngine;

/// <summary>
/// Класс который инстантиирует объекты-корабли по заданным условиям.
/// В данный момент не оптимизирован под пул объектов
/// </summary>
public class ShipBuilder : MonoBehaviour
{
	//FIXME: Добавить работу с пулом объектов
	[Header("Префабы кораблей")]
	public GameObject[] shipPrefabs;

	[Header("Префабы боссов")]
	public GameObject[] bossShipPrefabs;

	/// <summary>
	/// Метод строит случайный корабль и заданного массива префабов
	/// </summary>
	/// <returns></returns>
	public GameObject BuildRandomShip()
	{
		GameObject newShip = Instantiate(shipPrefabs[Random.Range(0, shipPrefabs.Length)], Vector3.zero, Quaternion.identity);

		newShip.GetComponent<BaseShip>().useRandomColor = true;
		return newShip;
	}

	public GameObject CreateBossShip()
	{
		//FIXME: Индекс из массива боссов
		GameObject newShip = Instantiate(bossShipPrefabs[0], Vector3.zero, Quaternion.identity);
		newShip.GetComponent<BaseShip>().useRandomColor = true;
		return newShip;
	}


}
