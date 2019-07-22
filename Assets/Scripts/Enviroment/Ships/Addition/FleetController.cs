using System.Collections;
using UnityEngine;
using static Constants;

public class FleetController : MonoBehaviour
{
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
				ship.respawnEvent.AddListener(() => RespawnShip(ship));
				MoveShip(ship);
			}	
		}
	}

	private void RespawnShip(BaseShip ship)
	{
		//TODO:Сделать респаун
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
			Debug.Log("StopAttack");
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

		//Интро. Босс спускается к игроку
		LeanTween.moveLocalY(bossShip, bossGamePoint.y, BOSS_INTRO_TIME).setOnComplete(() => bossShip.GetComponent<BossSuperShip>().StartAttackPhase());
	}

	private void StopAttack() => StopCoroutine(attackCoroutine);
}
