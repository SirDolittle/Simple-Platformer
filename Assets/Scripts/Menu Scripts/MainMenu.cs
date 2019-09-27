using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //this code is used for the main menu as well as other menus within the game. 

    public string startLevel;
    public string levelSelect;

    public void newgame()
    {
        Application.LoadLevel(startLevel);//due to the "startLevel" veriable being public. it allows me to chnage what level to load within the unity engine. 
    }

    public void levelselect()
    {
        Application.LoadLevel(levelSelect);
    }
    public void QuitGame()
    {
        Application.Quit();//simply quits the application when called. 
    }
}
