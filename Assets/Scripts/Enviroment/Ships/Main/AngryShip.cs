using UnityEngine;
/// <summary>
///Агрессивный корабль. Более мощный и скорострельный.
/// </summary>
public class AngryShip : BaseShip
{
	public override void Start()
	{
		//TODO: Вынести в JSON
		maxShootRate = 10; 
		dmg = 6;
		shootForce = 5;

		base.Start();
	}
}
