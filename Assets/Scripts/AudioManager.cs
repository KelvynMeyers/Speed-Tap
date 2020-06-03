using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    // TODO: Implement a volume section to settings, also include sliders
    // Foundations learned from Brackeys

    //// VARIABLES
    
    public Sound[] sounds;
    public static AudioManager instance;

    //// PUBLIC FUNCTIONS

    // Searches AudioManager for specified sound and plays if valid
    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        s.source.volume = s.volume;
        s.source.pitch = s.pitch;

        if(s == null)
        {
            Debug.LogWarning("No sound by the name of '"+soundName+"' could be found!");
            return;
        } 

        s.source.Play();
    }

    // Searches AudioManager for specified sound and stops if valid
    public void Stop(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        if(s == null)
        {
            Debug.LogWarning("No sound by the name of '"+soundName+"' could be found!");
            return;
        } 

        s.source.Stop();
    }

    // Searches AudioManager for specified sound and determines if currently playing
    public bool IsSoundPlaying(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        if(s == null)
        {
            Debug.LogWarning("No sound by the name of '"+soundName+"' could be found!");
            return false;
        } 

        return s.source.isPlaying;
    }

    //// PRIVATE FUNCTIONS

    // Before scene activation, initiate AudioManager instance and load in audio sources
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.name = s.name;
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }

    // Scene started, play music
    private void Start()
    {
        Play("DefaultMusic");
    }

    

}
