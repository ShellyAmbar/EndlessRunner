using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject startingText;
    public static int numOfCoins;
    public Text coinsText;
    
    void Start()
    {
        numOfCoins = 0;
        isGameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        coinsText.text = "Coins: " + numOfCoins;
        if (SwipeManager.tap) {
            isGameStarted = true;
            Destroy(startingText);
        }
        
    }
}
