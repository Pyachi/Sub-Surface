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
            if (PlayerPrefs.GetFloat("MasterVol") != 0)
                MainAudioMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat("MasterVol")) * 40 - 80);
            else
                MainAudioMixer.SetFloat("MasterVolume", -80f);
        }

        if (PlayerPrefs.HasKey("MusicVol"))
        {
            if (PlayerPrefs.GetFloat("MusicVol") != 0)
                MainAudioMixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVol")) * 40 - 80);
            else
                MainAudioMixer.SetFloat("MusicVolume", -80f);
        }

        if (PlayerPrefs.HasKey("SFXVol"))
        {
            if (PlayerPrefs.GetFloat("SFXVol") != 0)
                MainAudioMixer.SetFloat("SFXVolume", Mathf.Log10(PlayerPrefs.GetFloat("SFXVol")) * 40 - 80);
            else
                MainAudioMixer.SetFloat("SFXVolume", -80f);
        }
    }

    public static void Play(string name)
    {
        var s = Array.Find(_i.sounds, sound => sound.name == name);
        s?.source.Play();
    }

    public static void PlayOneShot(string name)
    {
        var s = Array.Find(_i.sounds, sound => sound.name == name);
        s?.source.PlayOneShot(s.clip);
    }

    public static void StopPlaying(string name)
    {
        var s = Array.Find(_i.sounds, item => item.name == name);
        s?.source.Stop();
    }

    public static void SetVolume(string name, float volume)
    {
        var s = Array.Find(_i.sounds, item => item.name == name);
        if (s == null) return;
        s.source.volume = volume;
    }

    public static void SetPitch(string name, float pitch)
    {
        var s = Array.Find(_i.sounds, item => item.name == name);
        if (s == null) return;
        s.source.pitch = pitch;
    }
}