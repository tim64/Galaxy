using UnityEngine;
using UnityEngine.SceneManagement;
using static Constants;

public class MusicController : MonoBehaviour
{
	public static void LoadMusic(string musicName)
	{
		AudioManager.PlayMusic("Music/" + musicName);
	}
}
