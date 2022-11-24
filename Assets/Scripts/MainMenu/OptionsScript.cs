using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class OptionsScript : MonoBehaviour
{
    public Toggle fullscreen, vsync;
    public List<ResolutionItem> resolutions = new List<ResolutionItem>();
    private int SelectRes;
    public Text resolutionLabel;
    public AudioMixer MainAudioMixer;
    public Text MasterLabel, MusicLabel, SFXLabel;
    public Slider MasterSlider, MusicSlider, SFXSlider; 
    
    // Start is called before the first frame update
    void Start()
    {
        //set vsync and fullscreen toggles on startup
        fullscreen.isOn = Screen.fullScreen;
        
        if (QualitySettings.vSyncCount == 0)
        {
            vsync.isOn = false;
        }
        else
        {
            vsync.isOn = true;
        }

        bool foundRes = false;

        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].width && Screen.width == resolutions[i].width)
            {
                foundRes = true;
                SelectRes = i;
                updateResLabel();
            }
        }

        if (!foundRes)
        {
            ResolutionItem newitem = new ResolutionItem();
            newitem.width = Screen.width;
            newitem.height = Screen.height;
            
            resolutions.Add(newitem);
            SelectRes = resolutions.Count - 1;
            
            updateResLabel();
        }

        //grab saved volume and set sliders to it
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            MasterSlider.value = PlayerPrefs.GetFloat("MasterVol");
        }
        if (PlayerPrefs.HasKey("MusicVol"))
        {
            MusicSlider.value = PlayerPrefs.GetFloat("MusicVol");
        }
        if (PlayerPrefs.HasKey("SFXVol"))
        {
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVol");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resleft()
    {
        SelectRes--;
        if (SelectRes < 0)
        {
            SelectRes = 0;
        }
        
        updateResLabel();
    }

    public void ResRight()
    {
        SelectRes++;
        if (SelectRes > resolutions.Count-1)
        {
            SelectRes = resolutions.Count-1;
        }
        
        updateResLabel();
    }

    public void updateResLabel()
    {
        resolutionLabel.text = resolutions[SelectRes].width.ToString() + " x " + resolutions[SelectRes].height.ToString();
    }

    public void applySettings()
    {
        if (vsync.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        
        Screen.SetResolution(resolutions[SelectRes].width, resolutions[SelectRes].height, fullscreen.isOn);
    }

    public void SetMasterVolume()
    {
        MasterLabel.text = MasterSlider.value.ToString();
        MainAudioMixer.SetFloat("MasterVolume", (MasterSlider.value * 0.8f) - 80);
        PlayerPrefs.SetFloat("MasterVol", MasterSlider.value);
    }
    
    public void SetMusicVolume()
    {
        MusicLabel.text = MusicSlider.value.ToString();
        MainAudioMixer.SetFloat("MusicVolume", (MusicSlider.value * 0.8f) - 80);
        PlayerPrefs.SetFloat("MusicVol", MusicSlider.value);
    }
    
    public void SetSFXVolume()
    {
        SFXLabel.text = SFXSlider.value.ToString();
        MainAudioMixer.SetFloat("SFXVolume", (SFXSlider.value * 0.8f) - 80);
        PlayerPrefs.SetFloat("SFXVol", SFXSlider.value);
    }
}

[System.Serializable]

public class ResolutionItem
{
    public int width, height;
}
