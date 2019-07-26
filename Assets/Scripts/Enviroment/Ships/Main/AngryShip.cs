using System.Collections;
using UnityEngine;
using static Constants;

/// <summary>
///Агрессивный корабль. Более мощный и скорострельный.
/// </summary>
public class AngryShip : BaseShip
{
	private bool isRaged = true;

	public override void Start()
	{
		shootRate = ANGRY_SHIP_SHOOT_RATE;
		damage = ANGRY_SHIP_DAMAGE;
		shootForce = ANGRY_SHIP_SHOOT_FORCE;
		useRandomShootRange = false;

		StartCoroutine(Rage());

		base.Start();
	}

	/// <summary>
	///  Иногда данный тип кораблей впадает в "ярость"
	///  Они начанаю крутится и активно стрелять
	/// </summary>
	/// <returns></returns>
	private IEnumerator Rage()
	{
		while (true)
		{
			yield return new WaitForSeconds(ANGRY_SHIP_RAGE_PERIOD + ANGRY_SHIP_RAGE_ANIMATION_TIME);

			if (isRaged && target == null)  
			{
				shootRate = ANGRY_SHIP_RAGE_SHOOT_RATE;
				LeanTween.rotateAroundLocal(gameObject, Vector3.back, -360, ANGRY_SHIP_RAGE_ANIMATION_TIME).setOnComplete(() => shootRate = ANGRY_SHIP_SHOOT_RATE);
				isRaged = false;
			}
			else
			{
				isRaged = !isRaged;
			}
		}
	}

	public override void Activate()
	{
		base.Activate();
	}
}

