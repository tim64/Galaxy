using UnityEngine;

/// <summary>
/// Класс, который случайно перекрашивает спрайты кораблей, с помощью шейдера
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class ShipColorizer : MonoBehaviour
{
	public Shader HSLShader;
	public bool autoColorize;

	private Material newColorMaterial;

	private void Start()
	{
		if (autoColorize) RandomColorize(GetComponent<SpriteRenderer>());
	}

	/// <summary>
	/// Случайно покрасить переданный спрайт
	/// </summary>
	/// <param name="sprite"></param>
	public void RandomColorize(SpriteRenderer sprite)
	{
		float randomX = Random.Range(-0.5f, 0.5f);
		float randomY = Random.Range(-0.5f, 0.5f);
		float randomZ = Random.Range(-0.1f, 0.3f);

		newColorMaterial = new Material(HSLShader);
		newColorMaterial.SetVector("_HSLAAdjust", new Vector4(randomX, randomY, randomZ, 0));
		sprite.material = newColorMaterial;
	}
}
