using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioMixerGroup masterMixerGroup;
    public AudioMixerGroup sfxMixerGroup;
    public AudioMixerGroup bgmMixerGroup;
   
    public AudioSource[] audioSource;
    public AudioClip[] audioClips;

    public enum Music
    {
        Master,
        BGM,
        SFX
    }
    

    private void SetVolume(float volume, Music music)
    {
        volume = Mathf.Clamp01(volume);
        volume = Mathf.Log10(volume) * 20;
        
        switch (music)
        {
            case Music.Master:
                masterMixerGroup.audioMixer.SetFloat("masterVolume", volume);
                break;
            case Music.BGM:
                bgmMixerGroup.audioMixer.SetFloat("bgmVolume", volume);
                break;
            case Music.SFX:
                sfxMixerGroup.audioMixer.SetFloat("sfxVolume", volume);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(music), music, null);
        }
    }
    {
        audioMixerGroup.audioMixer.SetFloat()
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(int index)
    {
        foreach (AudioSource source in audioSource)
        {
            if (!source.isPlaying)
            {
                source.clip = audioClips[index];
                source.Play();
                
            }
        }   
    }
}
