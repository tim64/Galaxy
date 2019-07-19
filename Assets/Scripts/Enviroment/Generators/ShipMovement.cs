using System.Collections;
using UnityEngine;

/// <summary>
/// Класс реализует перемещение флота кораблей в "старом стиле", по шагам
/// </summary>
public class ShipMovement : MonoBehaviour
{
	private readonly int moveXTime = 2;
	private readonly int maxPosX = 10;
	private readonly int currentMaxPosX = 5;

	private int posX;
	private int posY = -1;
	private int direction = 1;

	private readonly float stepTweenTime = 0.1f;

	private void Start()
	{
		posX = (int)gameObject.transform.position.x;
		StartCoroutine(StartTween());
	}

	private IEnumerator StartTween()
	{
		while (true)
		{
			yield return new WaitForSeconds(moveXTime);
			posX += direction;
			LeanTween.moveLocalX(gameObject, posX, stepTweenTime).setOnComplete(MoveDown);
		}
	}

	private void MoveDown()
	{
		if (posX % maxPosX == 0)
		{
			LeanTween.moveLocalY(gameObject, posY, stepTweenTime).setOnComplete(ChangeDirection);
		}
	}

	private void ChangeDirection()
	{
		posY -= 1;
		direction *= -1;
	}
}
