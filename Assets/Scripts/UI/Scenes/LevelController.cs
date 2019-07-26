using UnityEngine;
using UnityEngine.SceneManagement;
using static Constants;

/// <summary>
/// Класс для выбора текущего уровня и перехода к сцене Game
/// </summary>
public class LevelController : MonoBehaviour
{
	/// <summary>
	/// Текущий уровень
	/// </summary>
	public static int currentLevelIndex = 1;

	private void Start()
	{
		MusicController.LoadMusic("Boss");
	}

	/// <summary>
	/// Данный метод вызывается через UI event на кнопках
	/// </summary>
	/// <param name="levelId"></param>
	public void LevelSelect(int levelId)
	{
		currentLevelIndex = levelId;
		SceneManager.LoadScene(SCENE_GAME);
	}

	/// <summary>
	/// Перейти на след. уровень
	/// </summary>
	public static void GoToNextLevel()
	{
		currentLevelIndex += 1;
		SceneManager.LoadScene(SCENE_GAME);
	}

	/// <summary>
	/// Перейти в меню
	/// </summary>
	public void GoToMenu()
	{
		SceneManager.LoadScene(SCENE_MENU);
	}
}
