using UnityEngine;
using UnityEngine.UI;
using static Constants;

public class FadeIntroText : MonoBehaviour
{
    public void Show()
    {
		GetComponent<Text>().text = Level.currentLevelData.LevelName;
		GetComponent<Text>().CrossFadeAlpha(0, 0, false);
		GetComponent<Text>().CrossFadeAlpha(1, CROSS_FADE_TIME, false);
		LeanTween.delayedCall(CROSS_FADE_DALAY_TIME, FadeOut);
	}

	private void FadeOut() => GetComponent<Text>().CrossFadeAlpha(0, CROSS_FADE_TIME, false);
}
