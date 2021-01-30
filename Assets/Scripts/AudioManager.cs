using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	private static AudioManager instance;

	public static AudioManager Instance { get => instance; set => instance = value; }

	private void Awake()
	{
		if(instance != null && instance != this) Destroy(this.gameObject);
		else instance = this;
	}

	/// <summary>
	/// Plays an audioclip at the given position and volume.
	/// </summary>
	/// <param name="pos"> Where to play the audio clip. (world coordinates)</param>
	/// <param name="clip"> Which audioclip to play. </param>
	/// <param name="volume"> How loud it should be. </param>
	void PlayAudioAtPosition(Vector3 pos, AudioClip clip, float volume)
	{
		AudioSource.PlayClipAtPoint(clip, pos, volume);
	}
}
