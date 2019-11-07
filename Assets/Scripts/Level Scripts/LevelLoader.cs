using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    //this script is used to allow the player to move onto differnet levels when they get to the end of the level.

    public DataCollection dataCollection;
    private bool playerInZone;
    public GameObject NextLevel;
    public bool levelComplete = false;
    PlayerStats playerStats;
    // Use this for initialization

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Start () {
        //sets the bool to false
        playerInZone = false; 
	}
	
	// Update is called once per frame
	void Update () {
        //this is applyed to the levelexit object. When the player is colliding with the exit and presses "W" it calles the "PauseC" function 
        if (Input.GetKeyDown(KeyCode.W) && playerInZone)
        {
            playerStats.LevelStats();
            Debug.Log(SceneManager.GetActiveScene().name+ "= " + dataCollection.LevelCompletionTime);
            Debug.Log(SceneManager.GetActiveScene().name + " deaths = " + dataCollection.LevelDeathCount);
            Debug.Log(SceneManager.GetActiveScene().name + " HealthPacks = " + dataCollection.HealthPacksPickedUp);
            PauseC();
            
        }
   	}
    //detects player collision
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            playerInZone = true; 
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
        }
    }
    //this code is used to paues the game. time.timescale pauses the game as it sets the timescale to 0. 
    public void PauseC()
    {
        if (Time.timeScale == 0) //time.timescale pauses the game as it sets the timescale to 0.
        {
            Time.timeScale = 1;//time.timescale unpauses the game as it sets the timescale to .
            NextLevel.SetActive(false);//this deactiates the nextlevel canvas.
        }
        else if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            NextLevel.SetActive(true);//this actiates the nextlevel canvas.
        }
    }
}