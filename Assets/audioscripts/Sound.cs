using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public AudioMixerGroup mixer;

    public float volume = 1f;  // No range limit
    public float pitch = 1f;   // No range limit

    public bool loop = false;

    [HideInInspector]
    public AudioSource source; // Will be assigned in AudioManager
}
