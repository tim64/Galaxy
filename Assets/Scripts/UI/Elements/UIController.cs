using UnityEngine;

public class UIController : MonoBehaviour
{
	public Pause pausePopup;
	public Finish finishPopup;
	public FadeIntroText introText;

	public static UIController instance;

	void Start() => instance = this;

	public void ShowIntroText()
	{
		introText.Show();
	}

	public void ShowPause()
	{
		pausePopup.Open();
	}

	public void EndGame(bool isWin)
	{
		finishPopup.OpenAndEndGame(isWin);
	}
}
