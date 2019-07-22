using UnityEngine;
using UnityEngine.Events;
using UnityNightPool;

public class RemoveFX : MonoBehaviour
{
	//public UnityEvent finishFXEvent;

	private void Start()
	{
		//if (finishFXEvent == null)
		//{
		//	finishFXEvent = new UnityEvent();
		//}
	}

	public void RemoveFXtoPool()
	{
		//finishFXEvent.Invoke();
		GetComponent<PoolObject>().Return();
	}
}
