﻿using System.Collections;
using UnityEngine;
using UnityNightPool;
using static Constants;

/// <summary>
/// Класс пули для игрока и врагов
/// объект обязательно должен содержать компонент PoolObject, так как все пули из пула
/// </summary>

public class Bullet : MonoBehaviour
{
	public bool isPlayerBullet;
	public float damage;

	Renderer render;

	private void Start()
	{
		render = GetComponent<Renderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == ENEMY_TAG)
		{
			if (isPlayerBullet)
			{
				collision.GetComponent<BaseShip>().DamageShip(damage);
				GetComponent<PoolObject>().Return();
				
			}
		}

		if (collision.gameObject.tag == PLAYER_TAG)
		{
			if (!isPlayerBullet)
			{
				collision.GetComponent<Player>().Damage(damage);
				GetComponent<PoolObject>().Return();
			}
		}

		if (collision.gameObject.tag == BULLET_PLAYER_TAG)
		{
			collision.GetComponent<PoolObject>().Return();
			GetComponent<PoolObject>().Return();
		}
	}

	void Update()
	{
		if (!render.isVisible)
		{
			GetComponent<PoolObject>().Return();
		}
	}
}