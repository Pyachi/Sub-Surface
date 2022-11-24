using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string levelname;

    public GameObject optionsScreen;
    public GameObject tutorialScreen;

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
