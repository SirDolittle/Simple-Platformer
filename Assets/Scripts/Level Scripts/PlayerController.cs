using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerController : MonoBehaviour
{
    //MaxSpeed is the max amount of speed the player can get. 
    public float maxspeed = 10f;
    public float jumpSpeed = 15f;
    //Grounded bool variable set to false for later dection
    bool grounded = false;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        //create a veriable for the Animator component
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 0f;
        Rigidbody2D rigidbody = this.GetComponent<Rigidbody2D>();
        //Move right 

        if (GameObject.Find("Player").GetComponent<PlayerHealth>().isPlayerDead == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                //this part makes sure that the player can't go over the max speed.
                movement = -maxspeed;
                //This part adds the velocity to the rigidbody of the player. 
                rigidbody.velocity = new Vector2(movement, rigidbody.velocity.y);
                transform.localScale = new Vector3(-1.0f, transform.localScale.y, transform.localScale.z);
                //code which starts an animation when the "a" key is pressed.
                anim.SetInteger("Animation State", 1);
            }
            //Move left
            else if (Input.GetKey(KeyCode.D))
            {
                movement = maxspeed;
                rigidbody.velocity = new Vector2(movement, rigidbody.velocity.y);
                transform.localScale = new Vector3(1.0f, transform.localScale.y, transform.localScale.z);
                anim.SetInteger("Animation State", 1);
            }
            //jumping
            if (Input.GetKey(KeyCode.Space))
            {
                //This if statment checks if the player is colliding with another object.
                if (grounded)
                {
                    //if the player isn't colliding with an object it will run this code. It give the player the ability to jump. 
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
                    anim.SetInteger("Animation State", 3);
                }
            }
        }
        //resting animation if no keys are pressed.
        if (Input.anyKey == false)
        {
            anim.SetInteger("Animation State", 2);
        }
        
    }
    //Player Ground detection 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Ground")//this means that only gameobjects with the name ground can allow the player to jump
            grounded = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Ground")
        {
            grounded = false;
        }
    }
}
