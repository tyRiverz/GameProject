using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    AudioSource myAudio;
    public static int soundNumber = 1;
    public static bool isPlayerDead = false;
    public static bool deathSound = false;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        PlayByIndex(soundNumber);

    }

    void Start()
    {
        isPlayerDead = false;
        deathSound = false;
        //Play("Theme");
    }

    void Update()
    {
        if (!myAudio.isPlaying && !isPlayerDead)
        {
            PlayByIndex(soundNumber);
        }
        if (isPlayerDead && !deathSound)
        {
            myAudio.Stop();
            Play("AfterDeath");
            deathSound = true;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void PlayByIndex(int index)
    {
        Sound s = sounds[index];

        if (s == null)
        {
            Debug.LogWarning("Sound: " + index.ToString() + " not found!");
            return;
        }
        s.source.Play();
        myAudio = s.source;


        soundNumber++;
       if(soundNumber >= 5)
        {
            soundNumber = 1;
        }
    }    
}
