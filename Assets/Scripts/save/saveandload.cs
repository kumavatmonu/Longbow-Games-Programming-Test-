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
        Debug.Log("game saved");
        SetSaveScore(ScoreManager.score);
        SetSaveHealth((int)PlayerHealth.instance.healthSlider.value);

        PlayerMovement.instance.savepos();

        Debug.Log(GetSaveHealth());
        
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

        PlayerMovement.instance.loadpos(getxAxis(), getyAxis(), getzAxis());

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

    public float getxAxis()
    {
        return PlayerPrefs.GetFloat("xa");
    }

    public void setxAxis(float x)
    {
        PlayerPrefs.SetFloat("xa", x);
    }

    public float getyAxis()
    {
        return PlayerPrefs.GetFloat("ya");
    }
    public void setyAxis(float y)
    {
        PlayerPrefs.SetFloat("ya", y);
    }

    public float getzAxis()
    {
        return PlayerPrefs.GetFloat("za");
    }
    public void setzAxis(float z)
    {
        PlayerPrefs.SetFloat("za", z);
    }
}
