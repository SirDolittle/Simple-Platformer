using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
public class CheckPoint : MonoBehaviour {
    //calls the levelmanager object in the engine and gives it a veriable.
    PlayerStats playerStats;
    public LevelManager levelManager;
    private bool checkPointAcitvated = false; 
    Vector3 checkPointLocation;
    // Use this for initialization
    void Start()
    {
        //applys the levelmanager game object to the veriable.
        levelManager = FindObjectOfType<LevelManager>();
        playerStats = FindObjectOfType <PlayerStats>(); 
    }


    // Update is called once per frame
    void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {//if the object with name "player" collides with what ever object has this scrpit applyed to it will set the objects position(the checkPoint) as the players spawn point. 
        if (other.tag == "Player" && checkPointAcitvated == false)
        {
            levelManager.currentCheckpoint = gameObject;
            checkPointLocation = transform.position;
            playerStats.checkPointHits++;
            Debug.Log(playerStats.checkPointHits);
            

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        checkPointAcitvated = true;
    }
}
