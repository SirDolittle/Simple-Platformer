using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    public int packNumber;
    public int deathCount;
    public static float totalTimeInlevel;
    public static string pastLevel;
    public bool levelComplete = false;
    private string currentLevel;
    private LevelManager levelManager;
    PickUpHealth pickUpHealth;
    private 

    // Start is called before the first frame update
    void Awake()
    {
        currentLevel = SceneManager.GetActiveScene().name;
        levelManager = FindObjectOfType<LevelManager>();


    }

    // Update is called once per frame
    void Update()
    { 
        deathCount = GameObject.FindWithTag("GameController").GetComponent<LevelManager>().totalPlayerDeathCount;
        pickUpHealth = FindObjectOfType<PickUpHealth>();
        levelComplete = GameObject.FindWithTag("Finish").GetComponent<LevelLoader>().levelComplete;
        if (levelComplete == true)
        {
            LevelStats();

        }
    }

    void AppExitStats()
    {
        totalTimeInlevel += Time.timeSinceLevelLoad;

        Debug.Log(pastLevel);

        AnalyticsEvent.Custom("Level_Exit on " + (currentLevel) , new Dictionary<string, object>
          {
            {"Death_Count", deathCount },
            {"Time_Elasped", Time.timeSinceLevelLoad  },
            {"Total Time In level", totalTimeInlevel },
            {"Number of health packs picked up", packNumber },
            {"A Tester?", levelManager.isATester},
            });
    }

    public void LevelStats()
    {
        totalTimeInlevel += Time.timeSinceLevelLoad;

        AnalyticsEvent.Custom((currentLevel) + "_Complete", new Dictionary<string, object>
          {
            {"Level completed", SceneManager.GetActiveScene().name},
            {"Death_Count", deathCount },
            {"Time_Elasped", Time.timeSinceLevelLoad  },
            {"Total Time In level", totalTimeInlevel },
            {"Number of health packs picked up", packNumber },
            {"A Tester?", levelManager.isATester},

            });
    }

    public void LevelRestartStats()
    {

        totalTimeInlevel += Time.timeSinceLevelLoad;

        Debug.Log(pastLevel);

        AnalyticsEvent.Custom((SceneManager.GetActiveScene().name) + "_Restarted", new Dictionary<string, object>
          {
            {"Level Restarted", SceneManager.GetActiveScene().name},
            {"Time_Elasped", Time.timeSinceLevelLoad },
            {"Number of health packs picked up", packNumber },
            {"A Tester?", levelManager.isATester},

            });

        Debug.Log(totalTimeInlevel);
    }

    public void ResetTime()
    {
        totalTimeInlevel = 0f;
    }


    private void OnApplicationQuit()
    {
        AppExitStats();
    }

}
