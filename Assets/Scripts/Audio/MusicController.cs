using UnityEngine;

/// <summary>
/// Класс для загрузки различной музыки
/// </summary>
public class MusicController : MonoBehaviour
{
	/// <summary>
	/// Загрузить музыку по имени файла
	/// </summary>
	/// <param name="musicName"></param>
	public static void LoadMusic(string musicName) => AudioManager.PlayMusic("Music/" + musicName);
}
