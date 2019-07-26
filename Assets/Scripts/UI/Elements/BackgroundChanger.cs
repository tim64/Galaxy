using UnityEngine;

/// <summary>
/// Класс для изменения фона игры, в зависимости от выбранного уровня
/// </summary>
public class BackgroundChanger : MonoBehaviour
{
	public Sprite[] backgrounds;

	private SpriteRenderer backSprite;

	private void Start()
    {
		backSprite = GetComponent<SpriteRenderer>();
		backSprite.sprite = backgrounds[LevelController.currentLevelIndex - 1];
	}

}
