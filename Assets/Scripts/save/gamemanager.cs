using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public static gamemanager instance;

    public bool IsNewGame;

    public GameObject startCanvas, PlayCanvas;

    private void Awake()
    {
        instance = this;
       startCanvas.SetActive(true);
        PlayCanvas.SetActive(false);
        Time.timeScale = 0;
    }
}
