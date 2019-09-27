using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//access the name space UI

public class HUD : MonoBehaviour {

    public Sprite[] health;//creates an arry 

    public Image HealthUI;

    public PlayerHealth player;
	
	void Start ()
    {
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();//Allows us to access the object with the player tag to accsess the health of a player. 

	}


    void Update()
    {
        HealthUI.sprite = health[player.ourHealth];//calls the image required dependant on the players health. 
	}
}
