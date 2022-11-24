using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _i;
    public Sound[] sounds;

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