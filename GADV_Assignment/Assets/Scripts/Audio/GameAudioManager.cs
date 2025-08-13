using System;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public Sound[] music, sfx;
    public AudioSource musicSource, sfxSource;
    public static GameAudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }  
    }

    private void Start()
    {
        PlayMusic("GameMusic");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(music, x => x.name == name);
        if (s != null) 
        {
            musicSource.clip = s.audioClip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfx, x => x.name == name);
        if (s != null)
        {
            if (sfxSource.isPlaying && sfxSource.clip == s.audioClip)
            {
                return;
            }

            sfxSource.clip = s.audioClip;
            sfxSource.Play();
        }
    }
}
