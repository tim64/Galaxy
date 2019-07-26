using UnityEngine;
using UnityEngine.UI;
using static Constants;

/// <summary>
/// Класс показывает и скрывает интро-текст
/// </summary>
public class FadeIntroText : MonoBehaviour
{
	/// <summary>
	/// Показать интро-текст
	/// </summary>
    public void Show()
    {
		GetComponent<Text>().text = Level.currentLevelData.LevelName;
		GetComponent<Text>().CrossFadeAlpha(0, 0, false);
		GetComponent<Text>().CrossFadeAlpha(1, CROSS_FADE_TIME, false);
		LeanTween.delayedCall(CROSS_FADE_DALAY_TIME, FadeOut);
	}

	private void FadeOut() => GetComponent<Text>().CrossFadeAlpha(0, CROSS_FADE_TIME, false);
}
