using UnityEngine;
using UnityNightPool;

/// <summary>
/// Класс, с помощью которого убирается объект после анимации (взрывы и т.п.)
/// </summary>
public class RemoveFX : MonoBehaviour
{
	/// <summary>
	/// Убрать объект в пул
	/// </summary>
	public void RemoveFXtoPool()
	{
		GetComponent<PoolObject>().Return();
	}
}
