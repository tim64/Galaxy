using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
	[Header("Point")]
	public Transform gameCenter;
	public Transform bossRespPoint;
	public Transform bossGamePoint;

	public static WaypointController instance;

	void Start()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance == this)
		{
			Destroy(gameObject);
		}
	}
}
