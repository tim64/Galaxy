using UnityEngine;

/// <summary>
/// Модифицированный Debug, который активирует логи только в случае DebugBuild или Editor
/// </summary>
public static class CDebug {
	
	public static void Log(object message, Object context = null)
	{
		if(Debug.isDebugBuild)
			Debug.Log(message, context);
	}
	
	public static void LogWarning(object message, Object context = null)
	{
		if(Debug.isDebugBuild)
			Debug.LogWarning(message, context);
	}
	
	public static void LogError(object message, Object context = null)
	{
		if(Debug.isDebugBuild)
			Debug.LogError(message, context);
	}
	
	public static void DrawLine(Vector3 start, Vector3 end, Color color = default(Color), float duration = 0, bool depthTest = false)
	{
		if(Debug.isDebugBuild)
			Debug.DrawLine(start, end, color, duration, depthTest);
	}
	
	public static void DrawRay(Vector3 start, Vector3 dir, Color color = default(Color), float duration = 0, bool depthTest = false)
	{
		if(Debug.isDebugBuild)
			Debug.DrawRay(start, dir, color, duration, depthTest);
	}
}
