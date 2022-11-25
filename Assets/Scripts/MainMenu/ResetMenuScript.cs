using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMenuScript : MonoBehaviour
{
    public GameObject optionsMenu;
    
    public void ReturnToOptions()
    {
        optionsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetInt("SpeedLevel", 1);
        PlayerPrefs.SetInt("HealthLevel", 1);
        PlayerPrefs.SetInt("DamageLevel", 1);
        PlayerPrefs.SetInt("FireRateLevel", 1);
        PlayerPrefs.SetInt("RapidFireLevel", 1);
        PlayerPrefs.SetInt("Money", 1000000000);
        optionsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
    
}
