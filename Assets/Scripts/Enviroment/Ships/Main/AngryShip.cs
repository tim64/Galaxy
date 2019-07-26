using System.Collections;
using UnityEngine;
using static Constants;

/// <summary>
///Агрессивный корабль. Более мощный и скорострельный.
/// </summary>
public class AngryShip : BaseShip
{
	private bool isRaged;

	public override void Start()
	{
		shootRate = ANGRY_SHIP_SHOOT_RAGE;
		damage = ANGRY_SHIP_DAMAGE;
		shootForce = ANGRY_SHIP_SHOOT_FORCE;

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
		while (true && target != null)
		{
			//Добавляем случайное значение, чтобы было разнообразие в поведении кораблей
			yield return new WaitForSeconds(ANGRY_SHIP_RAGE_PERIOD + ANGRY_SHIP_RAGE_ANIMATION_TIME + Random.Range(-1, 2));

			isRaged = !isRaged;

			if (isRaged)
			{
				shootRate = ANGRY_SHIP_RAGE_SHOOT_RATE;
				LeanTween.rotateAroundLocal(gameObject, Vector3.back, -360, ANGRY_SHIP_RAGE_ANIMATION_TIME);
			}
			else
			{
				shootRate = ANGRY_SHIP_SHOOT_RAGE;
			}
		}
	}
}

