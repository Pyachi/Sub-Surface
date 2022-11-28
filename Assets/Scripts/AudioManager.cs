using System;
using UnityEngine;
using UnityEngine.Audio;

//Written By:
//Sarah Glass
//Mark Scheidker
public class AudioManager : MonoBehaviour
{
    private static AudioManager _i;
    public Sound[] sounds;
    public AudioMixer MainAudioMixer;

    private void Awake()
    {
        _i = this;
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.group;
        }

        //set the audio volumes to whatever was stored last
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            //check for zero, it would break the log function needed to linearly scale volume 
            // set to -80 (off) if it's zero
            if (PlayerPrefs.GetFloat("MasterVol") != 0)
                MainAudioMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat("MasterVol")) * 40 - 80);
            else
                MainAudioMixer.SetFloat("MasterVolume", -80f);
        }

        //do the same as master volume here
        if (PlayerPrefs.HasKey("MusicVol"))
        {
            if (PlayerPrefs.GetFloat("MusicVol") != 0)
                MainAudioMixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVol")) * 40 - 80);
            else
                MainAudioMixer.SetFloat("MusicVolume", -80f);
        }

        //do the same as master volume here
        if (PlayerPrefs.HasKey("SFXVol"))
        {
            if (PlayerPrefs.GetFloat("SFXVol") != 0)
                MainAudioMixer.SetFloat("SFXVolume", Mathf.Log10(PlayerPrefs.GetFloat("SFXVol")) * 40 - 80);
            else
                MainAudioMixer.SetFloat("SFXVolume", -80f);
        }
    }

    //play a standard sound
    public static void Play(string name)
    {
        var s = Array.Find(_i.sounds, sound => sound.name == name);
        s?.source.Play();
    }

    //play a sound that can stack
    public static void PlayOneShot(string name)
    {
        var s = Array.Find(_i.sounds, sound => sound.name == name);
        s?.source.PlayOneShot(s.clip);
    }

    //stop playing a sound
    public static void StopPlaying(string name)
    {
        var s = Array.Find(_i.sounds, item => item.name == name);
        s?.source.Stop();
    }
    
    
    //set the volume of an existing sound
    public static void SetVolume(string name, float volume)
    {
        var s = Array.Find(_i.sounds, item => item.name == name);
        if (s == null) return;
        s.source.volume = volume;
    }
    
    //set the pitch of an existing sound
    public static void SetPitch(string name, float pitch)
    {
        var s = Array.Find(_i.sounds, item => item.name == name);
        if (s == null) return;
        s.source.pitch = pitch;
    }
}