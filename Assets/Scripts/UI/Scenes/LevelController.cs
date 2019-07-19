﻿using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс для выбора текущего уровня и перехода к сцене Game
/// </summary>
public class LevelController : MonoBehaviour
{
	/// <summary>
	/// Текущий уровень
	/// </summary>
	public static int currentLevel;

	/// <summary>
	/// Данный метод вызывается через UI event на кнопках
	/// </summary>
	/// <param name="levelId"></param>
	public void LevelSelect(int levelId)
	{
		currentLevel = levelId;
		SceneManager.LoadScene(2);
	}
}