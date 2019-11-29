using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    public int packNumber;
    public int deathCount;
    public int checkPointHits; 
    public static float totalTimeInlevel;
    public static string pastLevel;
    public bool levelComplete = false;
    private string currentLevel;
    private LevelManager levelManager;
    PickUpHealth pickUpHealth;
    public DataCollection dataCollection;
    public Scoreboard scoreboard; 

    // Start is called before the first frame update
    void Awake()
    {
        currentLevel = SceneManager.GetActiveScene().name;
        levelManager = FindObjectOfType<LevelManager>();
       

    }

  

    // Update is called once per frame
    void Update()
    {
        dataCollection.LevelCompletionTime += Time.deltaTime;
        deathCount = GameObject.FindWithTag("GameController").GetComponent<LevelManager>().totalPlayerDeathCount;
        pickUpHealth = FindObjectOfType<PickUpHealth>();
        levelComplete = GameObject.FindWithTag("Finish").GetComponent<LevelLoader>().levelComplete;
        if (levelComplete == true)
        {
            LevelStats();

        }

    }

    public void LevelStats()
    {
        totalTimeInlevel += Time.timeSinceLevelLoad;

        if(currentLevel == "Level 1")
        {

            scoreboard.currentLevelOneTime = dataCollection.LevelCompletionTime;

        } else if (currentLevel == "Level 2")
        {
            scoreboard.currentLevelTwoTime = dataCollection.LevelCompletionTime;

        }
        else if (currentLevel == "Level 3")
        {
            scoreboard.I_TotalCompletion.Add(totalTimeInlevel);
            scoreboard.currentLevelThreeTime = dataCollection.LevelCompletionTime;
        }


        AnalyticsEvent.Custom((currentLevel) + "_Complete", new Dictionary<string, object>
          {
            {"Total Death_Count", dataCollection.LevelDeathCount },
            {"Time_Elasped", Time.timeSinceLevelLoad  },
            {"Total Time In level", dataCollection.LevelCompletionTime },
            {"Number of health packs picked up", dataCollection.HealthPacksPickedUp },
            {"Number of Checkpoints hit", checkPointHits },
            {"A Tester?", levelManager.isATester},

            });
    }

    public void LevelRestartStats()
    {

        totalTimeInlevel += Time.timeSinceLevelLoad;

        Debug.Log(pastLevel);

        AnalyticsEvent.Custom((SceneManager.GetActiveScene().name) + "_Restarted", new Dictionary<string, object>
          {
            {"Time_Elasped", Time.timeSinceLevelLoad },
            {"health packs picked up", packNumber },
            {"Checkpoints hit before restart", checkPointHits }, 
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
        dataCollection.LevelCompletionTime = 0;
        dataCollection.LevelDeathCount = 0;
        dataCollection.HealthPacksPickedUp = 0;

        if (currentLevel == "Level 1")
        {
            scoreboard.I_LevelOneCompletion.Add(0);
            scoreboard.I_LevelTwoCompletion.Add(0);
            scoreboard.I_LevelThreeCompletion.Add(0);
            scoreboard.I_TotalCompletion.Add(0);
        }
        else if (currentLevel == "Level 2")
        {
            scoreboard.I_LevelTwoCompletion.Add(0);
            scoreboard.I_LevelThreeCompletion.Add(0);
            scoreboard.I_TotalCompletion.Add(0);
        }
        else if (currentLevel == "Level 3")
        {
            scoreboard.I_LevelThreeCompletion.Add(0);
            scoreboard.I_TotalCompletion.Add(0);
        }

    }

}
