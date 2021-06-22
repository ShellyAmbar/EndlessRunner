using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public int levelNumber;
    public void ReplayGame() {
      
        SceneManager.LoadSceneAsync("Level1");

    }
    public void QuiteGame()
    {
     
        Application.Quit();

    }


}
