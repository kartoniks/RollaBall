using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
	void Awake () {
		foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
	}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, x => x.soundName == name);
        if(s==null)
        {
            Debug.LogError("sound not found " + name);
            return;
        }
        s.source.Play();
    }
}
