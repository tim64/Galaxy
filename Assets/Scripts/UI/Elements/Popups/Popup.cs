using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using static Constants;

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

	public void Close()
	{
		isOpen = !isOpen;
		Time.timeScale = isOpen ? 0 : 1;
		gameObject.SetActive(isOpen);
		onOpen.Invoke();
	}

	public void Open()
	{
		isOpen = !isOpen;
		Time.timeScale = isOpen ? 0 : 1;
		gameObject.SetActive(isOpen);
		onOpen.Invoke();
	}

	public void RestartGame()
	{
		LeanTween.reset();
		SceneManager.LoadScene(SCENE_GAME, LoadSceneMode.Single);
	}

	public void GoToMenu()
	{
		LeanTween.reset();
		SceneManager.LoadScene(SCENE_MENU, LoadSceneMode.Single);
	}

	public void GoToNextLevel()
	{
		LeanTween.reset();
		SceneManager.LoadScene(SCENE_GAME, LoadSceneMode.Single);
		LevelController.GoToNextLevel();
	}

	private void OnDestroy()
	{
		Time.timeScale = 1;
	}
}
