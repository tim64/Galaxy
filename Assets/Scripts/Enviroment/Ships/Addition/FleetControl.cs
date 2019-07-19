using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class FleetControl : MonoBehaviour
{
	public ShipBuilder builder;

	private BaseShip[] ships;
	private readonly int attackRate = 2; //TODO: Вынести в JSON
	private readonly Transform shipSquad;
	private Transform player;
	private Vector2 shipStartPos;
	private Coroutine attackCoroutine;

	private void Start()
	{
		player = GameObject.Find("AttackPoint").transform;
		ships = GetComponentsInChildren<BaseShip>();
		attackCoroutine = StartCoroutine(Attack());
	}

	private IEnumerator Attack()
	{
		while (true)
		{
			yield return new WaitForSeconds(attackRate);
			BaseShip ship = GetRandomShip();
			if (ship != null)
			{
				GameObject shipPlaceholder = new GameObject();
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
		ships = GetComponentsInChildren<BaseShip>();
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
		Transform bossRespPoint = WaypointController.instance.bossRespPoint;

		//Точка где заканчивается интро-анимация
		Transform bossGamePoint = WaypointController.instance.bossGamePoint;

		//Создание босса
		GameObject bossShip = builder.CreateBossShip();
		bossShip.transform.position = bossRespPoint.transform.position;

		//Интро. Босс спускается к игроку
		LeanTween.moveLocalY(bossShip, bossGamePoint.position.y, 5).setOnComplete(() => bossShip.GetComponent<BossShip>().StartAttack());
	}

	private void StopAttack() => StopCoroutine(attackCoroutine);
}
