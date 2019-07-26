using UnityEngine;
using System.Collections;

/// <summary>
/// Класс для корректной работы AudioManager
/// Добавляет к обынчным audiosource кастомное поведение
/// </summary>
public class Audio : MonoBehaviour
{
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
		GetComponent<AudioSource>().PlayOneShot(audioClip);
		yield return new WaitForSeconds(audioClip.length);
		Destroy(gameObject);
	}

	/// <summary>
	/// Проиграть звук в цикле
	/// </summary>
	/// <param name="audioClip"></param>
	public void PlaySoundLoop(AudioClip audioClip)
	{
		GetComponent<AudioSource>().clip = audioClip;
		GetComponent<AudioSource>().loop = true;
		GetComponent<AudioSource>().Play();
	}

	/// <summary>
	/// Остановить звук
	/// </summary>
	public void StopSound()
	{
		GetComponent<AudioSource>().Stop();
		Destroy(gameObject);
	}
}