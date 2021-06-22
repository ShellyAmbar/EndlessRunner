using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    public Material[] skyboxes;
    public int levelNumber;

    void Awake()
    {
        RenderSettings.skybox = skyboxes[levelNumber];
    }
}
