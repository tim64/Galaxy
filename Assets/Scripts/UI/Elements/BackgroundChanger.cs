using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
	public Sprite[] backgrounds;

	private SpriteRenderer backSprite;

	void Start()
    {
		backSprite = GetComponent<SpriteRenderer>();
		backSprite.sprite = backgrounds[LevelController.currentLevelIndex - 1];
	}

}
