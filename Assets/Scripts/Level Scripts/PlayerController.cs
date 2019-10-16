using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerController : MonoBehaviour
{
    //MaxSpeed is the max amount of speed the player can get. 
    public float maxspeed = 10f;
    public float jumpSpeed = 15f;
    public float wallJumpPush = 10f;
    private GroundDection groundDection;
    private WallDetection wallDetection;
    //Grounded bool variable set to false for later dection
    bool grounded = false;
   public bool isJumping = false;
    Animator anim;
    public Rigidbody2D PlayerRigidBody;
  
    // Use this for initialization
    void Start()
    {
        //create a veriable for the Animator component
        anim = GetComponent<Animator>();
        PlayerRigidBody = this.GetComponent<Rigidbody2D>();
        groundDection = FindObjectOfType<GroundDection>();
        wallDetection = FindObjectOfType<WallDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 0f;
        
       
        //Move right 

        if (GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().isPlayerDead == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                //this part makes sure that the player can't go over the max speed.
                movement = -maxspeed;
                //This part adds the velocity to the rigidbody of the player. 
                PlayerRigidBody.velocity = new Vector2(movement, PlayerRigidBody.velocity.y);
                transform.localScale = new Vector3(-1.0f, transform.localScale.y, transform.localScale.z);
                //code which starts an animation when the "a" key is pressed.
                anim.SetInteger("Animation State", 1);
            }
            //Move left
            else if (Input.GetKey(KeyCode.D))
            {
                movement = maxspeed;
               PlayerRigidBody.velocity = new Vector2(movement,PlayerRigidBody.velocity.y);
                transform.localScale = new Vector3(1.0f, transform.localScale.y, transform.localScale.z);
                anim.SetInteger("Animation State", 1);
            }
            //jumping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //This if statment checks if the player is colliding with another object.
                if (groundDection.grounded == true || wallDetection.isOnWall == true)
                {
                    isJumping = true; 
                    //if the player isn't colliding with an object it will run this code. It give the player the ability to jump. 
                    PlayerRigidBody.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
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
}
