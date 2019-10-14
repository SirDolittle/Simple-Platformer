using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;
    private GameObject player;

    // Use this for initialization
    bool isColliding;

    void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    void OnTriggerEnter2D(Collider2D other)
    {//if the object with the tag "player" collides with this object it will take away 1 life and call the "RespawnPlayer" function from the levelmanager script. 

        if (other.name == "Player")
        {
            player.GetComponent<PlayerHealth>().ourHealth -= 1;//this finds the gameobject "player" and then calls the playerhealth scrpit 
            levelManager.RespawnPlayer();

        }
    }

}
