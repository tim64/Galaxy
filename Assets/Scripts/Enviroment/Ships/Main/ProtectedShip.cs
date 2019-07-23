using UnityEngine;
/// <summary>
/// Класс описывает корабли в силовом поле
/// </summary>
public class ProtectedShip : BaseShip
{
    public GameObject protectFXPrefab;
    private bool onProtected = true;
	private GameObject armor;

	private float armorHP;

	public override void Start()
	{
		armorHP = hp;
		base.Start();
	}

	private void CreateProtected()
    {
        armor = Instantiate(protectFXPrefab);
        armor.transform.parent = transform;
        armor.transform.localPosition = Vector3.zero;
    }

	public override void Activate()
	{
		base.Activate();
		CreateProtected();
	}

	/// <summary>
	/// Данный вид корабля сначала унечтожает силовое поле
	/// </summary>
	public override void DamageShip(float damage)
	{
		if (onProtected)
		{
			if ((armorHP -= damage) <= 0)
			{
				attackState = true;
				onProtected = false;
				Destroy(armor);
			}
		}
		else
		{
			base.DamageShip(damage);
		}
	}
}
