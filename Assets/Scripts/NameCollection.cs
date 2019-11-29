using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class NameCollection : MonoBehaviour
{
    public Scoreboard scoreboard;
    private bool hasubmitted;
    private bool hasEnteredSomething;
    // Start is called before the first frame update


   public void InputCheck()
    {
        hasEnteredSomething = true; 
    }

   public void AddToPlayerList()
    {
        if (hasubmitted == false && hasEnteredSomething == true )
        {
            hasubmitted = true; 
            scoreboard.currentName = (gameObject.GetComponent<InputField>().text);
        }
   }
}
