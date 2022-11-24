using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string mainMenuScene;
    public GameObject PauseMenu;
    public bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                PauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                isPaused = true;
                PauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoToUpgraes()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        //SceneManager.LoadScene(upgradesScene)
    }
    
    public void ReturnToMain()
    {
        isPaused = false;
        //PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }
}
