using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
public class CheckPoint : MonoBehaviour {
    //calls the levelmanager object in the engine and gives it a veriable.
    public LevelManager levelManager;
    Vector3 checkPointLocation;
    // Use this for initialization
    void Start()
    {
        //applys the levelmanager game object to the veriable.
        levelManager = FindObjectOfType<LevelManager>();

    }


    // Update is called once per frame
    void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {//if the object with name "player" collides with what ever object has this scrpit applyed to it will set the objects position(the checkPoint) as the players spawn point. 
        if (other.name == "Player")
        {
            levelManager.currentCheckpoint = gameObject;
            Debug.Log("Activated Checkpoint" + transform.position);
            checkPointLocation = transform.position;
        }

        Analytics.CustomEvent("Last hit check Point", new Dictionary<string, object>
        {
            {"Last check point =", checkPointLocation}
        });


    }
}
