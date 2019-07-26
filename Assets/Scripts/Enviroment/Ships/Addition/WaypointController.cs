using UnityEngine;

/// <summary>
/// Класс, который содержит ссылки на "особые точки" на сцене
/// </summary>
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
