using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound{

    public AudioClip clip;
    public string soundName;
    public AudioSource source;

    [Range(0f, 1f)]
    public float volume;

}
