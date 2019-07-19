﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip : BaseShip
{
	private Vector3 startPos;

	private readonly float speed = Constants.BOSS_SPEED;
	private readonly float xScale = Constants.BOSS_X_PATH_SCALE;
	private readonly float yScale = Constants.BOSS_Y_PATH_SCALE;

	public bool attack;
	private float tweenTime;

	private Vector3 upVector;
	private Vector3 rightVector;

	private void Awake()
	{
		//TODO: Вынести в JSON
		maxShootRate = 0.25f;
		dmg = 10;
		shootForce = 8;
		useRandomShootRange = false;
	}

	/// <summary>
	/// Переопределенный метод старта
	/// </summary>
	public override void Start()
	{
		startPos = transform.position;
		base.Start();
	}

	/// <summary>
	/// Переопределенный метод BaseShip для стрельбы
	/// </summary>
	public override void Shoot()
	{
		if (attack)
		{
			base.Shoot();
		}
	}

	/// <summary>
	/// Метод начинает атаку босса на игрока и он активирует все свои компоненты
	/// После активации босс перестает быть неуязвимым
	/// </summary>
	public void StartAttack()
	{
		startPos = transform.position;
		attack = true;
		RemoveInvulnerability();
		ActivateGuns();	
	}

	private void RemoveInvulnerability()
	{
		GetComponent<Collider2D>().enabled = true;
	}

	private void ActivateGuns()
	{
		foreach (var item in GetComponentsInChildren<BossGun>())
		{
			item.GetComponent<BossGun>().enabled = true;
			item.GetComponent<Collider2D>().enabled = true;
		}
	}

	void Update()
	{
		if (attack)
		{
			tweenTime += Time.deltaTime;
			Vector3 upVector = Vector3.up * Mathf.Sin(tweenTime * speed);
			Vector3 rightVector = Vector3.right * Mathf.Sin(tweenTime / 2 * speed);
			transform.position = startPos + (rightVector * xScale) - (upVector * yScale);
		}
	}
}