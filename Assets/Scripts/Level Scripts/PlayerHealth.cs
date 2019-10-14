using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    //these are setting different variables to be used later in the code. 
    public int maxHealth = 3;
    public int ourHealth;
    private int damage = 1; 
    public GameObject DeathScreen;
    public float WaitTime = 1.0f;

    public bool isPlayerDead;

    Animator ani;
    // Use this for initialization
    void Start () {
        //takes the maxhealth (6) and makes the "ourHealth" veriable equal to that. 
        ourHealth = maxHealth;
        ani = GetComponent<Animator>();
        isPlayerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //this if statement will activate two things, the players death animation, and the destroy the player Ienemerator. 
        if (ourHealth <= 0)
        {
            isPlayerDead = true;
            ani.SetTrigger("PlayerDeath");
            //this is used as it can delay the death screen so that the animation can be shown. This basically runs the destory player functions but the function itself pauses it for 0.5f. 
            StartCoroutine("Destroyplayer" , WaitTime);//the WaitTime veriable is the timer and allows the "yeild return new waitforseondsrealtime" to work. 

        }
        if (ourHealth >= 3)
        {
            ourHealth = maxHealth; //this if statement stops the player's max health from going over the max. 
        }
    }

    public void DamagePlayer()
    {
        ourHealth = ourHealth - damage;
    }

    IEnumerator Destroyplayer(float Count)
     {
        yield return new WaitForSecondsRealtime(1f);//this pauses the count down, set by the waitTime.
        DestroyObject(gameObject);//destoryes the player game object.
        DeathScreen.SetActive(true);//activates the deathscreen. 
    }
            
 }
