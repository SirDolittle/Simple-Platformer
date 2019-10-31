using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public string Main;
    public string LoadNextLevel;



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

}
