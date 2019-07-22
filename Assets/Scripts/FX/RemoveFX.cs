using UnityEngine;
using UnityNightPool;

public class RemoveFX : MonoBehaviour
{

	public void RemoveFXtoPool()
	{
		GetComponent<PoolObject>().Return();
	}
}
