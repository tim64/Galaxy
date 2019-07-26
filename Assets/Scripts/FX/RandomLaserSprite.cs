using UnityEngine;

/// <summary>
/// Класс выбирает случайный спрайт лазера из доступных
/// </summary>
public class RandomLaserSprite : MonoBehaviour
{
	public Sprite[] lasersSpites;

	private void Start() => GetComponent<SpriteRenderer>().sprite = lasersSpites[Random.Range(0, lasersSpites.Length)];
}
