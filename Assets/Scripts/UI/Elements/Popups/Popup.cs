using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using static Constants;

/// <summary>
/// UI класс для любых всплывающих окон
/// </summary>
public class Popup : MonoBehaviour
{
	[HideInInspector]
	public UnityEvent onClose;
	[HideInInspector]
	public UnityEvent onOpen;

	private bool isOpen;

	private void Awake()
	{
		if (onClose == null)
		{
			onClose = new UnityEvent();
		}

		if (onOpen == null)
		{
			onOpen = new UnityEvent();
		}
	}

	/// <summary>
	/// Закрыть окно
	/// </summary>
	public void Close()
	{
		isOpen = !isOpen;
		Time.timeScale = isOpen ? 0 : 1;
		gameObject.SetActive(isOpen);
		onOpen.Invoke();
	}

	/// <summary>
	/// Открыть окно
	/// </summary>
	public void Open()
	{
		isOpen = !isOpen;
		Time.timeScale = isOpen ? 0 : 1;
		gameObject.SetActive(isOpen);
		onOpen.Invoke();
	}

	/// <summary>
	/// Перезапустить игру
	/// </summary>
	public void RestartGame()
	{
		LeanTween.reset();
		SceneManager.LoadScene(SCENE_GAME, LoadSceneMode.Single);
	}

	/// <summary>
	/// Выйти в меню
	/// </summary>
	public void GoToMenu()
	{
		LeanTween.reset();
		SceneManager.LoadScene(SCENE_MENU, LoadSceneMode.Single);
	}

	/// <summary>
	/// Перейти на след. уровень
	/// </summary>
	public void GoToNextLevel()
	{
		LeanTween.reset();
		SceneManager.LoadScene(SCENE_GAME, LoadSceneMode.Single);
		LevelController.GoToNextLevel();
	}

	/// <summary>
	/// При уничтожении окна, снять паузу
	/// </summary>
	private void OnDestroy()
	{
		Time.timeScale = 1;
	}
}
