using UnityEngine;
using UnityEngine.SceneManagement;

//Written By:
//Sarah Glass
//Mark Scheidker
public class MainMenuScript : MonoBehaviour
{
    public string levelname;

    public GameObject optionsScreen;
    public GameObject tutorialScreen;

    private void Start()
    {
        //if vsync has been saved, then set it to saved value
        if (PlayerPrefs.HasKey("VsyncOption")) QualitySettings.vSyncCount = PlayerPrefs.GetInt("VsyncOption");

        //setup money to zero if not set
        if (!PlayerPrefs.HasKey("Money")) PlayerPrefs.SetInt("Money", 1000000000);

        //setup player preferences for upgrades on initial startup
        if (!PlayerPrefs.HasKey("SpeedLevel")) PlayerPrefs.SetInt("SpeedLevel", 1);

        if (!PlayerPrefs.HasKey("HealthLevel")) PlayerPrefs.SetInt("HealthLevel", 1);

        if (!PlayerPrefs.HasKey("DamageLevel")) PlayerPrefs.SetInt("DamageLevel", 1);

        if (!PlayerPrefs.HasKey("FireRateLevel")) PlayerPrefs.SetInt("FireRateLevel", 1);

        if (!PlayerPrefs.HasKey("RapidfireLevel")) PlayerPrefs.SetInt("RapidfireLevel", 0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levelname);
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void OpenTutorial()
    {
        tutorialScreen.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialScreen.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}