using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Popup : MonoBehaviour
{
	[HideInInspector]
	public UnityEvent onClose;
	[HideInInspector]
	public UnityEvent onOpen;

	private bool isOpen;

	private void Awake()
	{
		if (onClose == null)
		{
			onClose = new UnityEvent();
		}

		if (onOpen == null)
		{
			onOpen = new UnityEvent();
		}
	}

	public void Close()
	{
		isOpen = !isOpen;
		Time.timeScale = isOpen ? 0 : 1;
		gameObject.SetActive(isOpen);
		onOpen.Invoke();
	}

	public void Open()
	{
		isOpen = !isOpen;
		Time.timeScale = isOpen ? 0 : 1;
		gameObject.SetActive(isOpen);
		onOpen.Invoke();
	}
}
