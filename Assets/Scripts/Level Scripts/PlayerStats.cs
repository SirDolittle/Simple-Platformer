using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    public int packNumber;
    public int deathCount;
    public bool levelComplete = false;
    private LevelManager levelManager;
    PickUpHealth pickUpHealth;
    private 

    // Start is called before the first frame update
    void Awake()
    {

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
        AnalyticsEvent.Custom("Level_Exit on " + (SceneManager.GetActiveScene().name) , new Dictionary<string, object>
          {
            {"Death_Count", deathCount },
            {"Time_Elasped", Time.timeSinceLevelLoad  },
            {"Number of health packs picked up", packNumber },
            {"A Tester?", levelManager.isATester},
            });
    }

    public void LevelStats()
    {
        AnalyticsEvent.Custom((SceneManager.GetActiveScene().name) + "_Complete", new Dictionary<string, object>
          {
            {"Level completed", SceneManager.GetActiveScene().name},
            {"Death_Count", deathCount },
            {"Time_Elasped", Time.timeSinceLevelLoad  },
            {"Number of health packs picked up", packNumber },
            {"A Tester?", levelManager.isATester},

            });
    }

    public void LevelRestartStats()
    {
        AnalyticsEvent.Custom((SceneManager.GetActiveScene().name) + "_Restarted", new Dictionary<string, object>
          {
            {"Level Restarted", SceneManager.GetActiveScene().name},
            {"Death_Count", deathCount },
            {"Time_Elasped", Time.timeSinceLevelLoad  },
            {"Number of health packs picked up", packNumber },
            {"A Tester?", levelManager.isATester},

            });
    }




    private void OnApplicationQuit()
    {
        AppExitStats();
    }

}
