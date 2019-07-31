using UnityEngine;
using System.Collections;

/// <summary>
/// Класс для корректной работы AudioManager
/// Добавляет к обынчным audiosource кастомное поведение
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{
	private AudioSource source;

	private void Awake()
	{
		source = GetComponent<AudioSource>();
	}

	/// <summary>
	/// Проиграть звуки 1 раз
	/// </summary>
	/// <param name="audioClip"></param>
	public void PlaySoundOnce(AudioClip audioClip)
	{
		StartCoroutine(PlaySoundCoroutine(audioClip));
	}

	IEnumerator PlaySoundCoroutine(AudioClip audioClip)
	{
		source.PlayOneShot(audioClip);
		yield return new WaitForSeconds(audioClip.length);
		Destroy(gameObject);
	}

	/// <summary>
	/// Проиграть звук в цикле
	/// </summary>
	/// <param name="audioClip"></param>
	public void PlaySoundLoop(AudioClip audioClip)
	{
		source.clip = audioClip;
		source.loop = true;
		source.Play();
	}

	/// <summary>
	/// Остановить звук
	/// </summary>
	public void StopSound()
	{
		source.Stop();
		Destroy(gameObject);
	}
}