using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Класс для переключение UI в меню и для перехода к сцене Levels
/// </summary>
public class MenuController : MonoBehaviour
{
	public GameObject mainContent;
	public GameObject settingContent;

	public void SwitchContent()
	{
		mainContent.SetActive(!mainContent.activeSelf);
		settingContent.SetActive(!mainContent.activeSelf);
	}

	public void PlayGame() => SceneManager.LoadScene(1);
}
