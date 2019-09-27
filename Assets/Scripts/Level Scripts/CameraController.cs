using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;

    // Use this for initialization
    void Start()
    {
        //sets 
        player = GameObject.FindGameObjectWithTag("Player");//This assigns the player gameobject to the player veriable.
        
    }

    // LateUpdate is called after Update each frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
        transform.position = new Vector3(posX, posY, transform.position.z);
        //this code uses Mathf.SmoothDamp which will move a assigned object to the position of the player through the player veriable. 
    }
}