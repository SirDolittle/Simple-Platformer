using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public DataCollection dataCollection;
    public string Main;
    public string LoadNextLevel;

    PlayerStats playerStats;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }


    public void Mainm()
    {
        Application.LoadLevel(Main);
    }

    public void GotoNextlevel()
    {
        Application.LoadLevel(LoadNextLevel);
        Time.timeScale = 1;
        

    }


    public void QuitGame()
    {
        Application.Quit();
    }

    private void LateUpdate()
    {
        dataCollection.LevelCompletionTime = 0;
        dataCollection.LevelDeathCount = 0;
        dataCollection.HealthPacksPickedUp = 0;
    }
}
