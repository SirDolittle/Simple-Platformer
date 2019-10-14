using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDection : MonoBehaviour
{
 public bool grounded = false;

    //Player Ground detection 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.name == "Ground")//this means that only gameobjects with the name ground can allow the player to jump
            grounded = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.name == "Ground")
        {
            grounded = false;
        }
    }
}
