using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public string Main;
    public string RestartLevel;
    public string NextLevel;
    PlayerStats playerStats;
    public DataCollection dataCollection;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void Mainm()
    {
        Application.LoadLevel(Main);
    }

    public void Restart()
    {
        Application.LoadLevel(RestartLevel);
        playerStats.LevelRestartStats();
        Time.timeScale = 1;
    }


    public void QuitGame()
    {
        Application.Quit();
    }
  
    
   
}
