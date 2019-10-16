using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour
{
    public bool isOnWall = false;

    //Player Ground detection 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")//this means that only gameobjects with the name ground can allow the player to jump
            isOnWall = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            isOnWall = false;
        }
    }
}
