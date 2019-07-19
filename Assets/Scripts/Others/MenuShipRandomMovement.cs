using System;
using System.Collections;
using UnityEngine;
using UnityNightPool;
using Random = UnityEngine.Random;

public class MenuShipRandomMovement : MonoBehaviour
{
	private Vector2 movement;

	private readonly float speed = 1f;
	private readonly float speedUPtime = 2f;
	private float currentTime;

	private Rigidbody2D rb;

	private void Awake() => rb = GetComponent<Rigidbody2D>();

	private void Update()
	{
		currentTime -= Time.deltaTime;
		if (currentTime <= 0)
		{
			var rand1 = Random.Range(-1f, 1f);
			var rand2 = Random.Range(-1f, 1f);
			movement = new Vector2(rand1, rand2);
			currentTime += speedUPtime;
		}
	}

	private void FixedUpdate() => rb.AddForce(movement * speed);
}
