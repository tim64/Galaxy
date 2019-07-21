using UnityEngine;
/// <summary>
/// Класс описывает корабли в силовом поле
/// </summary>
public class ProtectedShip : BaseShip
{
    public GameObject protectFXPrefab;
    private bool onProtected = true;
	private GameObject armor;

	public override void Start()
	{
		base.Start();
		CreateProtected();
	}

	private void CreateProtected()
    {
        armor = Instantiate(protectFXPrefab);
        armor.transform.parent = transform;
        armor.transform.localPosition = Vector3.zero;
    }

	/// <summary>
	/// Метод уничтожения корабля. Основное поведение наследуется от базового класса
	/// Данный вид корабля сначала унечтожает силовое поле
	/// </summary>
	public override void DestroyShip()
	{
		if (onProtected)
		{
			attackState = true;
			onProtected = false;
			Destroy(armor);
		}
		else
		{
			base.DestroyShip();
		}
	}
}
