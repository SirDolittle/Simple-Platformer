using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDection : MonoBehaviour
{
 public bool grounded = false;
    private PlayerController playerController;

    //Player Ground detection 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.name == "Ground")//this means that only gameobjects with the name ground can allow the player to jump
            grounded = true;
            playerController.isJumping = false;
    }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (playerController.isJumping == true)
        {
            grounded = false;
        }
    }

}
