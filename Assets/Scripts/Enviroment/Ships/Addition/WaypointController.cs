using UnityEngine;

public class WaypointController : MonoBehaviour
{
	[Header("Point")]
	public Transform gameCenter;
	public Transform bossRespPoint;
	public Transform bossGamePoint;
	public Transform attakPoint;

	public static WaypointController instance;

	void Start() => instance = this;
}
