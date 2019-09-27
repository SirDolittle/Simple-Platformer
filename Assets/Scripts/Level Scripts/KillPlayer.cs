using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public LevelManager levelManager;
    // Use this for initialization
    void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {//if the object with the tag "player" collides with this object it will take away 1 life and call the "RespawnPlayer" function from the levelmanager script. 
        
        if (other.name == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().ourHealth -= 1;//this finds the gameobject "player" and then calls the playerhealth scrpit 
            levelManager.RespawnPlayer();

        }
    }
}
