using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public string Main;
    public string RestartLevel;
       
    public void Mainm()
    {
        Application.LoadLevel(Main);
    }

    public void Restart()
    {
        Application.LoadLevel(RestartLevel);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
  
    
   
}
