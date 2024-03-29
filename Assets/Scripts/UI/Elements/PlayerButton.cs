﻿using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// UI кнопка для упраления игроком
/// </summary>
public class PlayerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
	public bool IsPressed
	{
		get;
		private set;
	}

	public void OnPointerDown(PointerEventData eventData) => IsPressed = true;

	public void OnPointerUp(PointerEventData eventData) => IsPressed = false;

	public void OnPointerExit(PointerEventData eventData) => IsPressed = false;
}