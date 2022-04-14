using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveandload : MonoBehaviour
{
    public static saveandload instance;

    private void Awake()
    {
        instance = this;
    }

    public void SaveGame()
    {
        SetSaveScore(ScoreManager.score);
        SetSaveHealth((int)PlayerHealth.instance.healthSlider.value);
        Debug.Log(GetSaveHealth());
        Debug.Log("game saved");
    }

    public void NewGame()
    {
        Time.timeScale = 1;
        gamemanager.instance.IsNewGame = true;
        ScoreManager.score = 0;

        PlayerHealth.instance.healthSlider.value = PlayerHealth.instance.startingHealth;
        PlayerHealth.instance.currentHealth = PlayerHealth.instance.startingHealth;

        gamemanager.instance.startCanvas.SetActive(false);
        gamemanager.instance.PlayCanvas.SetActive(true);
    }

    public void LoadSavedGame()
    {
        Time.timeScale = 1;
        gamemanager.instance.IsNewGame = false;
        ScoreManager.score = GetSaveScore();

        PlayerHealth.instance.healthSlider.value = GetSaveHealth();
        PlayerHealth.instance.currentHealth = GetSaveHealth();

        gamemanager.instance.startCanvas.SetActive(false);
        gamemanager.instance.PlayCanvas.SetActive(true);
    }

    //For health
    public int GetSaveHealth()
    {
       return PlayerPrefs.GetInt("PH");
    }

    public void SetSaveHealth(int health)
    {
        PlayerPrefs.SetInt("PH", health);
    }

    //For Score

    public int  GetSaveScore()
    {
       return PlayerPrefs.GetInt("PS");
    }

    public void SetSaveScore(int score)
    {
        PlayerPrefs.SetInt("PS", score);
    }
}
