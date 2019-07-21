using UnityEngine;

public class ObjectPool<T> : MonoBehaviour
	where T : Component
{
	[SerializeField] private int maxSize = 0;
	[SerializeField] private GameObject prefab = null;

	private T[] items;
	private int size;

	private void Awake()
	{
		Asserts.Fatal(prefab != null && prefab.GetComponent<T>() != null, "Invalid pool prefab ({0}).", typeof(T));
		size = maxSize;
		items = new T[maxSize];
		for (var i = 0; i < maxSize; i++)
		{
			var go = Instantiate(prefab);
			go.SetActive(false);
			go.transform.SetParent(transform);
			items[i] = go.GetComponent<T>();
		}
	}

	public T Pop(Transform newParent)
	{
		Asserts.Fatal(size > 0, "Pool is empty.");
		size--;
		var item = items[size];
		items[size] = null;
		item.gameObject.SetActive(true);
		item.transform.SetParent(newParent);
		return item;
	}

	public void Push(T item)
	{
		Asserts.Fatal(size < maxSize, "Pool is full.");
		items[size] = item;
		size++;
		item.gameObject.SetActive(false);
		item.transform.SetParent(transform);
	}
}
