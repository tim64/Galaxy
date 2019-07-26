using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс для перехода к сцене Levels и активации музыки
/// </summary>
public class MenuController : MonoBehaviour
{
	public GameObject mainContent;

	private void Start() => MusicController.LoadMusic("Menu");

	public void PlayGame() => SceneManager.LoadScene(1);
}
