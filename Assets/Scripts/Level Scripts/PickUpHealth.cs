using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
public class PickUpHealth : MonoBehaviour {

    PlayerStats playerStats;
    // Use this for initialization
    void Awake ()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && GameObject.Find("Player").GetComponent<PlayerHealth>().ourHealth < 3)
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().ourHealth += 1;
            playerStats.packNumber++;//this finds the gameobject "player" and then calls the playerhealth scrpit to add 1 to the ourhealth veriable. 
            DestroyObject(gameObject);//this simply destroyes the health pickup once it has made contact with the player. 
        }
    }
}
