using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenu : MonoBehaviour {


    public string Mainmenu;
    public string level1;
    public string level2;
    public string level3;
    public string level4;

    public void gameMenu()
    {
        Application.LoadLevel(Mainmenu);
    }
    public void Level1()
    {
        Application.LoadLevel(level1);
    }
    public void Level2()
    {
        Application.LoadLevel(level2);
    }

}
