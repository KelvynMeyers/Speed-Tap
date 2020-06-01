using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    // Foundations learned from Brackeys
    public Sound[] sounds;
    public static AudioManager instance;


    // TODO: Implement a volume section to settings, also include sliders
    // TODO: Better documentation
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

    private void Start()
    {
        Play("DefaultMusic");
    }

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

}
