using UnityEngine.UI;

public class Finish : Popup
{
	public Text finishLabel;
	public Button nextLevelBtn;

	public void OpenAndEndGame(bool isWin)
	{
		Open();
		finishLabel.text = isWin ? "Win!" : "Lose!";
		nextLevelBtn.gameObject.SetActive(isWin);
	}
}
