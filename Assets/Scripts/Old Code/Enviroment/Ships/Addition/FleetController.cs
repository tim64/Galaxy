using System.Collections;
using UnityEngine;
using static Constants;

/// <summary>
/// Класс, который управляет флотом
/// Он вызывает атаки кораблей и призывает боссов если корабли закончились
/// </summary>
public class FleetController : MonoBehaviour
{
	//Ссылка на билдер кораблей
	public ShipBuilder builder;

	private BaseShip[] ships;
	private Transform player;
	private Vector2 shipStartPos;
	private Coroutine attackCoroutine;

	private void Start()
	{
		player = WaypointController.instance.attakPoint;
		attackCoroutine = StartCoroutine(Attack());
	}

	private IEnumerator Attack()
	{
		while (true)
		{
			yield return new WaitForSeconds(FLEET_ATTACK_RATE);
			ships = GetComponentsInChildren<BaseShip>();
			BaseShip ship = GetRandomShip();
			if (ship != null)
			{
				MoveShip(ship);
			}	
		}
	}

	private void DestroyShip(BaseShip ship)
	{
		Destroy(ship.gameObject);
	}

	private void MoveShip(BaseShip ship) => ship.Attack(player);

	private BaseShip GetRandomShip()
	{
		if (ships.Length > 0)
		{
			return ships[Random.Range(0, ships.Length)];
		}
		else
		{
			//Конец битвы и возов босса
			StopAttack();
			SummonBoss();
			return null;
		}
	}

	private void SummonBoss()
	{
		//Точка появления босса
		Vector2 bossRespPoint = WaypointController.instance.bossRespPoint.position;

		//Точка где заканчивается интро-анимация
		Vector2 bossGamePoint = WaypointController.instance.bossGamePoint.position;

		//Создание босса
		GameObject bossShip = builder.CreateBossShip();
		bossShip.transform.position = bossRespPoint;

		//Музыкальная тема босса
		MusicController.LoadMusic("Boss");

		//Интро. Босс спускается к игроку
		LeanTween.moveLocalY(bossShip, bossGamePoint.y, BOSS_INTRO_TIME).setOnComplete(() => bossShip.GetComponent<BossShip>().StartAttackPhase());
	}

	private void StopAttack() => StopCoroutine(attackCoroutine);
}
