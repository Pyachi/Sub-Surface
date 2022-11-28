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

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                PauseMenu.SetActive(false);
                HUD.SetActive(true);
                Time.timeScale = 1f;
            }
            else
            {
                isPaused = true;
                PauseMenu.SetActive(true);
                HUD.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GoToUpgraes()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Upgrades");
    }

    public void ReturnToMain()
    {
        isPaused = false;
        //PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }

    public static bool IsGamePaused()
    {
        return isPaused;
    }
}