﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{

    public static int score;

    Text text;
    
    void Awake ()
    {
        text = GetComponent <Text> ();
        //if (gamemanager.instance.IsNewGame)
        //{
        //    score = 0;
        //}
        //else
        //{
        //    score = saveandload.instance.GetSaveScore();
        //}
       
    }

    void Update ()
    {
        text.text = "Score: " + score;
    }

}