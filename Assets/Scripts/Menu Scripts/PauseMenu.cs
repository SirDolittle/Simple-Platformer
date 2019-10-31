using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public string Main;
    public string RestartLevel;
    public string NextLevel;

    public void Mainm()
    {
        Application.LoadLevel(Main);
    }

    public void Restart()
    {
        Application.LoadLevel(RestartLevel);

        Time.timeScale = 1;
    }


    public void QuitGame()
    {
        Application.Quit();
    }
  
    
   
}
