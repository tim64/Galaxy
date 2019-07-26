using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс обабатывает поведение лайф-бара
/// </summary>
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
