using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
public class PlayerStats : MonoBehaviour
{
    private int packNumber;
    public int deathCount;
    public float timePlayed;
    public bool levelComplete = false;
    private bool ranOnce = false;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Awake()
    {

        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        deathCount = GameObject.FindWithTag("GameController").GetComponent<LevelManager>().totalPlayerDeathCount;
        timePlayed = Time.timeSinceLevelLoad;
        levelComplete = GameObject.FindWithTag("Finish").GetComponent<LevelLoader>().levelComplete;
        packNumber = GameObject.Find("HealthPickUp").GetComponent<PickUpHealth>().packNumber;
        if (levelComplete == true && ranOnce == false)
        {
            EndOfLevelStats();

        }
    }

    void AppExitStats()
    {
        AnalyticsEvent.Custom("Level_Exit", new Dictionary<string, object>
          {
            {"Death_Count", deathCount },
            {"Time_Elasped", timePlayed  },
            {"A Tester?", levelManager.isATester},
            });
    }

    void EndOfLevelStats()
    {
        ranOnce = true;
        AnalyticsEvent.Custom("Level_Complete", new Dictionary<string, object>
          {
            {"Death_Count", deathCount },
            {"Time_Elasped", timePlayed  },
             {"A Tester?", levelManager.isATester},

            });
        
    }

   public void PlayerHeathPickUP()
    {
        packNumber++;
        AnalyticsEvent.Custom("HealthPack_PickedU", new Dictionary<string, object>
          {
            {"Pack Number", packNumber },

            });
    }


    private void OnApplicationQuit()
    {
        AppExitStats();
    }

}
