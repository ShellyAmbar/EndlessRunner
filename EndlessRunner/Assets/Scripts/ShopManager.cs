using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int currentIndex;
    public GameObject[] characters;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = PlayerPrefs.GetInt("currentIndex", 0);
        foreach (GameObject character in characters) {
            character.SetActive(false);
        }
        characters[currentIndex].SetActive(true);
    }

   

    // Update is called once per frame
    void Update()
    {
        characters[currentIndex].SetActive(true);
    }

    public void changeNext() {
        characters[currentIndex].SetActive(false);
        currentIndex++;
        if(currentIndex == characters.Length){
            currentIndex = 0;
        }

        characters[currentIndex].SetActive(true);
        PlayerPrefs.SetInt("currentIndex", currentIndex);
    }

    public void changePrev()
    {
        characters[currentIndex].SetActive(false);
        currentIndex--;
        if (currentIndex == -1)
        {
            currentIndex = characters.Length-1;
        }

        characters[currentIndex].SetActive(true);
        PlayerPrefs.SetInt("currentIndex", currentIndex);
    }

}
