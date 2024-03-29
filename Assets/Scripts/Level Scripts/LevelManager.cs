﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    //calls objects in the unity and applys variables to them. 
    public GameObject currentCheckpoint;
    public bool hasRespawned; 
    private PlayerController player;
    public int totalPlayerDeathCount;


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
        totalPlayerDeathCount++;
        player.transform.position = currentCheckpoint.transform.position;

    }


}
