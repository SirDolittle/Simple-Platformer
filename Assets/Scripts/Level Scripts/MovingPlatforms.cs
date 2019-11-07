using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour {
    //these public veriables allow me to change these veriables within unity itself. 
    public GameObject platform;
    public float moveSpeed;
    private Transform currentPoint;
    public Transform[] points;
    public int pointSelection;

	// Use this for initialization
	void Start () {
        currentPoint = points[pointSelection];//these square brackets set an arry in which can be changed in the unity engine. 
	}
	
	// Update is called once per frame
	void Update ()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
        if(platform.transform.position == currentPoint.position)//saying if the platform is still.
        {
            pointSelection++;//this is what is actually moving the playform.
            if(pointSelection == points.Length)
            {
                pointSelection = 0;//this stops the platform from going past the points set in unity. 
            }
            currentPoint = points[pointSelection]; 
        }
	}
}
