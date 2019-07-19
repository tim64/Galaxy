using UnityEngine;

/// <summary>
/// Класс который инстантиирует объекты-корабли по заданным условиям.
/// В данный момент не оптимизирован под пул объектов
/// </summary>
public class ShipBuilder : MonoBehaviour
{
	//FIXME: Добавить работу с пулом объектов
	[Header("Префабы кораблей")]
	public GameObject baseShipPrefab;
	public GameObject angryShipPrefab;
	public GameObject protectedShipPrefab;
	public GameObject teleportShipPrefab;
	public GameObject quickShipPrefab;
	public GameObject bossShipPrefab;

	public GameObject BuildRandomShip()
	{
		GameObject newShip = new GameObject();

		int rand = Random.Range(0, 5);

		newShip = InstantiateShip(newShip, rand);

		newShip.GetComponent<BaseShip>().useRandomColor = true;
		return newShip;
	}

	private GameObject InstantiateShip(GameObject newShip, int rand)
	{
		if (rand == 0) newShip = Instantiate(baseShipPrefab, Vector3.zero, Quaternion.identity);
		if (rand == 1) newShip = Instantiate(protectedShipPrefab, Vector3.zero, Quaternion.identity);
		if (rand == 2) newShip = Instantiate(angryShipPrefab, Vector3.zero, Quaternion.identity);
		if (rand == 3) newShip = Instantiate(teleportShipPrefab, Vector3.zero, Quaternion.identity);
		if (rand == 4) newShip = Instantiate(quickShipPrefab, Vector3.zero, Quaternion.identity);
		return newShip;
	}

	public GameObject CreateBossShip()
	{
		GameObject newShip = Instantiate(bossShipPrefab, Vector3.zero, Quaternion.identity);
		newShip.GetComponent<BaseShip>().useRandomColor = true;
		return newShip;
	}


}
