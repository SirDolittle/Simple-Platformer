using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Scoreboard : ScriptableObject
{

    //player names
    public List<string> PlayerNames = new List<string>();
    //Individual times
    public List<float> I_TotalCompletion = new List<float>();
    public List<float> I_LevelOneCompletion = new List<float>();
    public List<float> I_LevelTwoCompletion = new List<float>();
    public List<float> I_LevelThreeCompletion = new List<float>();

    public string currentName;
    public float currentLevelOneTime;
    public float currentLevelTwoTime;
    public float currentLevelThreeTime;

}

