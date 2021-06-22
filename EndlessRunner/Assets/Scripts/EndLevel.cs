using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class EndLevel : MonoBehaviour
{
    public int levelIndex;
    public GameObject endScreen;
    // Start is called before the first frame update
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            endScreen.gameObject.SetActive(true);
            //Task.Delay(2000);
            //SceneManager.LoadSceneAsync(levelIndex, LoadSceneMode.Single);
        }
         
    }
}
