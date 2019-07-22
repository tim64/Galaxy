using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
	public Slider slider;
	public Player player;

    private void Start()
    {
		slider.maxValue = player.Hp;
		player.damageEvent.AddListener(ChangeSlider);

	}

	private void ChangeSlider()
	{
		slider.value -= player.lastDamage;
	}
}
