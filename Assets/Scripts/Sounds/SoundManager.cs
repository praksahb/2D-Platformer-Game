using System;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource soundEffect;
    public AudioSource soundMusic;

    //Doubt#
    //Unity editor still registers array as soundType in inspector
    public SoundType[] SoundsArray;

    private void Awake()
    {
        CreateLevelManager();
    }

    public bool IsMusicPlaying()
    {
        return soundMusic.isPlaying;
    }

    public bool IsSoundEffectPlaying()
    {
        return soundEffect.isPlaying;
    }

    private void Start()
    {
        //PlayMusic(Sounds.Music);
    }

    private void CreateLevelManager()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("Clip not found for sound type: " + sound);
        }
    }

    public void PlayEffect(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if(clip != null)
        {
            soundEffect.PlayOneShot(clip);
        } else
        {
            Debug.LogError("Clip not found for sound type: " + sound);
        }
    }

    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType audioItem = Array.Find(SoundsArray, item => item.soundType == sound);
        if(audioItem != null)
            return audioItem.soundClip;
        return null;
    }

    public void StopPlayMusic()
    {
        soundMusic.Stop();
    }

    public void StopPlayEffect()
    {
        soundEffect.Stop();
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    ButtonClick,
    Music,
    PlayerMove,
    PlayerJump,
    PlayerLand,
    PlayerDeath,
    EnemyDeath
}