using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public Toggle fullscreen, vsync;
    public List<ResolutionItem> resolutions = new List<ResolutionItem>();
    private int SelectRes;
    public Text resolutionLabel;
    
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
    
}

[System.Serializable]

public class ResolutionItem
{
    public int width, height;
}
