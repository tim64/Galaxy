using UnityEngine;

/// <summary>
/// простой контроллер игрового интерфейса
/// </summary>
public class UIController : MonoBehaviour
{
	public Pause pausePopup;
	public Finish finishPopup;
	public FadeIntroText introText;

	public static UIController instance;

	void Start() => instance = this;

	/// <summary>
	/// Показать интро текст
	/// </summary>
	public void ShowIntroText() => introText.Show();

	/// <summary>
	/// Показать паузу
	/// </summary>
	public void ShowPause() => pausePopup.Open();

	/// <summary>
	/// Закончить игру
	/// </summary>
	/// <param name="isWin"></param>
	public void EndGame(bool isWin) => finishPopup.OpenAndEndGame(isWin);
}
