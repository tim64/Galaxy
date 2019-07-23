using UnityEngine;

public class UIController : MonoBehaviour
{
	public Pause pausePopup;
	public Finish finishPopup;

	public static UIController instance;

	void Start() => instance = this;

	public void ShowPause()
	{
		pausePopup.Open();
	}

	public void EndGame(bool isWin)
	{
		finishPopup.OpenAndEndGame(isWin);
	}
}
