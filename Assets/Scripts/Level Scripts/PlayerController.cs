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
    private WallDetection wallDetection;
    bool isMovingRight = false;
    bool isMovingLeft = false;
    private LevelManager levelManager; 
    Animator anim;
    public Rigidbody2D PlayerRigidBody;
    public LayerMask mylayerMask;
    float movement = 0f;

    // Use this for initialization
    void Start()
    {
        //create a veriable for the Animator component
        anim = GetComponent<Animator>();
        PlayerRigidBody = this.GetComponent<Rigidbody2D>();
        wallDetection = FindObjectOfType<WallDetection>();
        levelManager = FindObjectOfType<LevelManager>(); 
    }

    void FixedUpdate()
    {

        //Move right 

        if (GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().isPlayerDead == false && levelManager.playerwaiting == false)
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
                isMovingLeft = true;
            }
            //Move left
            else if (Input.GetKey(KeyCode.D))
            {
                movement = maxspeed;
                PlayerRigidBody.velocity = new Vector2(movement, PlayerRigidBody.velocity.y);
                transform.localScale = new Vector3(1.0f, transform.localScale.y, transform.localScale.z);
                anim.SetInteger("Animation State", 1);
                isMovingRight = true;
            }
            else
            {

                PlayerRigidBody.velocity = new Vector2(Mathf.Lerp(PlayerRigidBody.velocity.x, 0, 0.8F), PlayerRigidBody.velocity.y);
            }


            //jumping
            if (Input.GetKey(KeyCode.Space))
            {
                // RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, mylayerMask);
                // If it hits something...
                if (Physics2D.Raycast(transform.position, -Vector2.up, 0.5f, mylayerMask) || wallDetection.isOnWall == true)
                {

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
