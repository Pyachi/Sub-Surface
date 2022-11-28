using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//Written By:
//Sarah Glass
//Mark Scheidker
public class OptionsScript : MonoBehaviour
{
    public Toggle fullscreen, vsync;
    public List<ResolutionItem> resolutions = new List<ResolutionItem>();
    public Text resolutionLabel;
    public AudioMixer MainAudioMixer;
    public Text MasterLabel, MusicLabel, SFXLabel;
    public Slider MasterSlider, MusicSlider, SFXSlider;
    public GameObject resetMenu;
    private int SelectRes;

    // Start is called before the first frame update
    private void Start()
    {
        //set vsync and fullscreen toggles on startup
        fullscreen.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
            vsync.isOn = false;
        else
            vsync.isOn = true;

        var foundRes = false;

        for (var i = 0; i < resolutions.Count; i++)
            if (Screen.width == resolutions[i].width && Screen.width == resolutions[i].width)
            {
                foundRes = true;
                SelectRes = i;
                updateResLabel();
            }

        if (!foundRes)
        {
            var newitem = new ResolutionItem();
            newitem.width = Screen.width;
            newitem.height = Screen.height;

            resolutions.Add(newitem);
            SelectRes = resolutions.Count - 1;

            updateResLabel();
        }

        //grab saved volume and set sliders to it
        if (PlayerPrefs.HasKey("MasterVol")) MasterSlider.value = PlayerPrefs.GetFloat("MasterVol");
        if (PlayerPrefs.HasKey("MusicVol")) MusicSlider.value = PlayerPrefs.GetFloat("MusicVol");
        if (PlayerPrefs.HasKey("SFXVol")) SFXSlider.value = PlayerPrefs.GetFloat("SFXVol");
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Resleft()
    {
        SelectRes--;
        if (SelectRes < 0) SelectRes = 0;

        updateResLabel();
    }

    public void ResRight()
    {
        SelectRes++;
        if (SelectRes > resolutions.Count - 1) SelectRes = resolutions.Count - 1;

        updateResLabel();
    }

    public void updateResLabel()
    {
        resolutionLabel.text = resolutions[SelectRes].width + " x " + resolutions[SelectRes].height;
    }

    public void applySettings()
    {
        if (vsync.isOn)
        {
            QualitySettings.vSyncCount = 1;
            PlayerPrefs.SetInt("VsyncOption", 1);
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            PlayerPrefs.SetInt("VsyncOption", 0);
        }

        Screen.SetResolution(resolutions[SelectRes].width, resolutions[SelectRes].height, fullscreen.isOn);
    }

    //set volumes based on input from sliders
    public void SetMasterVolume()
    {
        MasterLabel.text = MasterSlider.value.ToString();
        if (MasterSlider.value != 0)
            //use a logarithmic function to calculate volume, human hearing is logarithmic
            MainAudioMixer.SetFloat("MasterVolume", Mathf.Log10(MasterSlider.value) * 40 - 80);
        else
            MainAudioMixer.SetFloat("MasterVolume", -80f);
        PlayerPrefs.SetFloat("MasterVol", MasterSlider.value);
    }

    public void SetMusicVolume()
    {
        MusicLabel.text = MusicSlider.value.ToString();
        if (MusicSlider.value != 0)
            MainAudioMixer.SetFloat("MusicVolume", Mathf.Log10(MusicSlider.value) * 40 - 80);
        else
            MainAudioMixer.SetFloat("MusicVolume", -80f);
        PlayerPrefs.SetFloat("MusicVol", MusicSlider.value);
    }

    public void SetSFXVolume()
    {
        SFXLabel.text = SFXSlider.value.ToString();
        if (SFXSlider.value != 0)
            MainAudioMixer.SetFloat("SFXVolume", Mathf.Log10(SFXSlider.value) * 40 - 80);
        else
            MainAudioMixer.SetFloat("SFXVolume", -80f);
        PlayerPrefs.SetFloat("SFXVol", SFXSlider.value);
    }

    public void OpenResetMenu()
    {
        resetMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}

[Serializable]
public class ResolutionItem
{
    public int width, height;
}