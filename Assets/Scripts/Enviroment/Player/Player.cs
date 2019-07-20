using System;
using UnityEngine;
using UnityNightPool;

public class Player : MonoBehaviour
{
	public float speed = 2.0f;

	private bool isShooting;
	private readonly Rigidbody2D rb;
	private Vector2 playerPos;

	private readonly float shootRate = 0.2f;
	private readonly float shootForce = 10;

	public float hp = 100;

	private void Start() => playerPos = transform.position;

	private void Update()
    {
		if (Input.GetMouseButton(0) || (Input.GetKeyDown(KeyCode.Space) && !isShooting))
        {
			isShooting = true;

			PoolObject bullet = PoolManager.Get(6);
            bullet.transform.position = transform.position;

			bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * shootForce);
			bullet.GetComponent<Bullet>().Shoot();

			LeanTween.delayedCall(shootRate, () => isShooting = false);
        }

		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
		playerPos = new Vector3(Mathf.Clamp(xPos, -20, 20), playerPos.y, 0f);
		transform.position = playerPos;
	}

	public void Damage(float damage)
	{
		hp -= damage;

		if (hp <= 0)
		{
			DestroyPlayer();
		}
	}

	public void DestroyPlayer()
	{
		PoolObject fx = PoolManager.Get(7);
		fx.GetComponent<SpriteRenderer>().color = Color.yellow;
		fx.transform.position = transform.position;
		Destroy(gameObject);
	}
}