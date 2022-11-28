using UnityEngine;
using UnityEngine.SceneManagement;

//Written By:
//Sarah Glass
//Mark Scheidker
public class MenuController : MonoBehaviour
{
    public static bool isPaused;
    public string mainMenuScene;
    public GameObject PauseMenu;
    public GameObject HUD;
    
    private void Update()
    {
        //if the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            //if the game is already paused
            if (isPaused)
            {
                //unpause the game by turning off the pause menu, turning on the hud and setting the timescale to 1
                isPaused = false;
                PauseMenu.SetActive(false);
                HUD.SetActive(true);
                Time.timeScale = 1f;
            }
            else
            {
                //pause the game by turning off the hud, turing on the pause menu, and setting timescale to 0
                isPaused = true;
                PauseMenu.SetActive(true);
                HUD.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }

    public void ResumeGame()
    {
        //close the pause menu, set game to unpaused and set timescale to 1
        isPaused = false;
        PauseMenu.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GoToUpgrades()
    {   
        //unpause and go to the upgrades scene
        isPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Upgrades");
    }

    public void ReturnToMain()
    {
        //unpause and go to the main menu
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }

    public static bool IsGamePaused()
    {
        return isPaused;
    }
}