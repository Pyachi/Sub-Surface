using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string levelname;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levelname);
    }

    public void OpenOptions()
    {
        
    }
    
    public void CloseOptions()
    {
        
    }
    
    public void OpenTutorial()
    {
        
    }
    
    public void CloseTutorial()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
