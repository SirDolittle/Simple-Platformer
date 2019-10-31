using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    public int packNumber;
    public int deathCount;
    public float timePlayed;
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
        timePlayed = Time.timeSinceLevelLoad;
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
            {"Time_Elasped", timePlayed  },
            {"Number of health packs picked up", packNumber },
            {"A Tester?", levelManager.isATester},
            });
    }

    public void LevelStats()
    {
        AnalyticsEvent.Custom((SceneManager.GetActiveScene().name) + "_Complete", new Dictionary<string, object>
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
