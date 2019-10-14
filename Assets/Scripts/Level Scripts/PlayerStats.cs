using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
public class PlayerStats : MonoBehaviour
{
    public int deathCount;
    public float timePlayed;
    public bool levelComplete = false;
    private bool ranOnce = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        deathCount = GameObject.FindWithTag("GameController").GetComponent<LevelManager>().totalPlayerDeathCount;
        timePlayed = Time.timeSinceLevelLoad;
        levelComplete = GameObject.FindWithTag("Finish").GetComponent<LevelLoader>().levelComplete;

        if (levelComplete == true && ranOnce == false)
        {
            EndOfLevelStats();

        }
    }

    void EndOfLevelStats()
    {
        ranOnce = true;
        AnalyticsEvent.Custom("Level_Complete", new Dictionary<string, object>
          {
            {"Death_Count", deathCount },
            {"Time_Elasped", timePlayed  }

            });
        
    }


}
