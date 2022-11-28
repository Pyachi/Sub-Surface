using UnityEngine;

//Written By:
//Sarah Glass
//Mark Scheidker
public class ResetMenuScript : MonoBehaviour
{
    public GameObject optionsMenu;

    public void ReturnToOptions()
    {
        optionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetInt("SpeedLevel", 1);
        PlayerPrefs.SetInt("HealthLevel", 1);
        PlayerPrefs.SetInt("DamageLevel", 1);
        PlayerPrefs.SetInt("FireRateLevel", 1);
        PlayerPrefs.SetInt("RapidFireLevel", 0);
        PlayerPrefs.SetInt("Money", 0);
        optionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}