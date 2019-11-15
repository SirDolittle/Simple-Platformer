using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    //calls objects in the unity and applys variables to them. 
    public DataCollection dataCollection;
    public GameObject currentCheckpoint;
    public bool hasRespawned;
    public bool isATester;
    private PlayerController player;
    public int totalPlayerDeathCount;
    public float waitTime;
    public bool playerwaiting = false; 

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        //when this function is called it will "respawn" the player at the last checkpoint they touched. 
        Debug.Log("player Respawn");
        dataCollection.LevelDeathCount++;
        totalPlayerDeathCount++;
        player.transform.position = currentCheckpoint.transform.position;
        playerwaiting = true; 
        StartCoroutine("DelayMovement");
    }

    IEnumerator DelayMovement()
    {
        yield return new WaitForSeconds(waitTime);
        playerwaiting = false; 
    }

}
