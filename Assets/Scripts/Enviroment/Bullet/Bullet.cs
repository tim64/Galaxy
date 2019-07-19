using System.Collections;
using UnityEngine;
using UnityNightPool;

/// <summary>
/// Класс пули для игрока и врагов
/// объект обязательно должен содержать компонент PoolObject, так как все пули из пула
/// </summary>
[RequireComponent(typeof(PoolObject))]
public class Bullet : MonoBehaviour
{
	public bool isPlayerBullet;
	public int dmg;

	public void Shoot() => StartCoroutine(Destroy());

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			if (isPlayerBullet)
			{
				collision.GetComponent<BaseShip>().DestroyShip();
				GetComponent<PoolObject>().Return();
			}
		}

		if (collision.gameObject.tag == "Player")
		{
			if (!isPlayerBullet)
			{
				collision.GetComponent<Player>().Damage(dmg);
				GetComponent<PoolObject>().Return();
			}
		}
	}

	private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10f);
        GetComponent<PoolObject>().Return();
    }
}