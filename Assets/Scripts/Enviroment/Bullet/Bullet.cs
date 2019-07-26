using UnityEngine;
using UnityNightPool;
using static Constants;

/// <summary>
/// Класс пули для игрока и врагов
/// объект обязательно должен содержать компонент PoolObject, так как все пули из пула
/// </summary>
[RequireComponent(typeof(PoolObject))]
public class Bullet : MonoBehaviour
{
	/// <summary>
	/// Флаг о том, что это пуля игрока
	/// </summary>
	public bool isPlayerBullet;

	/// <summary>
	/// Урон пули
	/// </summary>
	public float damage;

	private Renderer render;

	private void Start() => render = GetComponent<Renderer>();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Определяем если попали в врага
		if (collision.gameObject.tag == ENEMY_TAG)
		{
			if (isPlayerBullet)
			{
				AudioManager.PlaySoundOnce(s_BULLET_COLLISION);
				collision.GetComponent<BaseShip>().DamageShip(damage);
				GetComponent<PoolObject>().Return();
				
			}
		}

		//Определяем если попали в игрока
		if (collision.gameObject.tag == PLAYER_TAG)
		{
			if (!isPlayerBullet)
			{
				AudioManager.PlaySoundOnce(s_BULLET_COLLISION);
				collision.GetComponent<Player>().Damage(damage);
				GetComponent<PoolObject>().Return();
			}
		}

		//Пули сталкиваются с друг другом
		if (collision.gameObject.tag == BULLET_PLAYER_TAG)
		{
			AudioManager.PlaySoundOnce(s_BULLET_COLLISION);
			collision.GetComponent<PoolObject>().Return();
			GetComponent<PoolObject>().Return();
		}
	}

	private void Update()
	{
		if (!render.isVisible)
		{
			GetComponent<PoolObject>().Return();
		}
	}
}