using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour {
    public GameObject Menu;
    // This code is used for the pausing of a menu.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//this if statement calls the PauseC function is the escape key is pressed. 
        {
            PauseC();
        }
    }

    public void PauseC()//this code pauses the game. By using time.timescale. Setting the time to 0 causes the time to stop and setting it to 1 resumes the game. 
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            Menu.SetActive(false);//this part activates the canvas for the menu.
        }
        else if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            Menu.SetActive(true);
        }
    }
}
