using System;
using UnityEngine;
using UnityEngine.Audio;

//Written By:
//Sarah Glass
//Mark Scheidker
[Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)] public float volume;

    [Range(.1f, 10f)] public float pitch;

    public bool loop;

    public AudioMixerGroup group;

    [HideInInspector] public AudioSource source;
}