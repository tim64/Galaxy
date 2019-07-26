using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Класс для управления музыкой и звуками
/// </summary>
public class AudioManager : MonoBehaviour
{
	public AudioClip[] audioSources;
	public GameObject audioPrefabSource;
	public Dictionary<string, AudioClip> audioClips;
	static GameObject audioPrefab;
	static GameObject instance;
	static AudioSource musicPlayer;
	public static AudioManager manager;
	Dictionary<string, Audio> aliveSounds;
	AudioListener al;

	private void Awake()
	{
		manager = this;
		al = GetComponent<AudioListener>();
		audioClips = new Dictionary<string, AudioClip>();

		foreach (AudioClip a in audioSources)
		{
			audioClips.Add(a.name, a);
		}

		instance = gameObject;
		audioPrefab = audioPrefabSource;
		musicPlayer = GetComponent<AudioSource>();
		aliveSounds = new Dictionary<string, Audio>();
	}

	/// <summary>
	/// Проиграть звук по его названию
	/// </summary>
	/// <param name="name"></param>
	public static void PlaySoundOnce(string name)
	{
		if (!manager.audioClips.ContainsKey(name))
		{
			return;
		}

		GameObject go = Instantiate(audioPrefab);
		go.transform.parent = instance.transform;
		Audio a = go.GetComponent<Audio>();
		a.PlaySoundOnce(manager.audioClips[name]);
	}

	/// <summary>
	/// Проиграть музыку по названию файла
	/// </summary>
	/// <param name="name"></param>
	public static void PlayMusic(string name)
	{
		if (musicPlayer.clip == null || musicPlayer.clip.name != name)
		{
			musicPlayer.clip = Resources.Load("Audio/" + name, typeof(AudioClip)) as AudioClip;
			musicPlayer.Stop();
			musicPlayer.loop = true;
			musicPlayer.Play();
		}
		else
		{
			musicPlayer.loop = true;
			musicPlayer.Play();
		}

		//По умолчанию музыка немного тише
		musicPlayer.volume = 0.75f;

	}
}