﻿using UnityEngine;
using UnityEngine.Audio;

// Sound class utilized by AudioManager
[System.Serializable]
public class Sound
{
    //// VARIABLES 
    public AudioClip clip;
    
    public string name;
    [Range(0f,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
