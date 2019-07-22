using System.Collections;
using UnityEngine;
using static Constants;

/// <summary>
/// Класс реализует перемещение флота кораблей в "старом стиле", по шагам
/// </summary>
public class ShipMovement : MonoBehaviour
{
	private readonly int moveXTime = FLEET_MOVE_TIME_X;
	private readonly int maxPosX = FLEET_MAX_POS_X;
	private readonly int currentMaxPosX = FLEET_CURRENT_POS_X;

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
