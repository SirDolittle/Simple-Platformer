using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
public class PickUpHealth : MonoBehaviour {

    int packNumber;


    // Use this for initialization
    void Start ()
    {
         

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && GameObject.Find("Player").GetComponent<PlayerHealth>().ourHealth < 6)
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().ourHealth += 1;//this finds the gameobject "player" and then calls the playerhealth scrpit to add 1 to the ourhealth veriable. 
            DestroyObject(gameObject);//this simply destroyes the health pickup once it has made contact with the player. 
            packNumber++;

            Analytics.CustomEvent("Health Pick ups", new Dictionary<string, object>
        {
            {"Number of Healthpack =", packNumber}
        });
        }
    }
}
