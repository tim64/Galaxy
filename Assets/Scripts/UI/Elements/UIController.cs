using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
	public GameObject pausePopup;

	public void ShowPause()
	{
		pausePopup.SetActive(!pausePopup.activeSelf);
		Time.timeScale = pausePopup.activeSelf ? 0 : 1;
		Debug.Log(Time.timeScale);
	}
}
