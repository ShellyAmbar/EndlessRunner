using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void startToPlay()
    {
        
        SceneManager.LoadSceneAsync("Level1");
    }

    public void goToShop()
    {

        SceneManager.LoadSceneAsync("Shop");
    }

    public void quitTheGame()
    {
        
        Application.Quit();
    }

    public void goToMenu()
    {

        SceneManager.LoadSceneAsync("Menu");
    }


}
