using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Noah.Scoreboards
{
    public class NameCollection : MonoBehaviour
    {
        private bool hasubmitted;
        private bool hasEnteredSomething;
        public DataCollection dataCollection;


        // Start is called before the first frame update


        public void InputCheck()
        {
            hasEnteredSomething = true;
        }

        public void AddToPlayerList(Text inputFieldText)
        {
            if (hasubmitted == false && hasEnteredSomething == true)
            {
                hasubmitted = true;
                ScoreboardEntryData newEntry = new ScoreboardEntryData();
                newEntry.entryName = inputFieldText.text;
                newEntry.entryTime = dataCollection.TotalTimeInGame;
                dataCollection.newEntry = newEntry; 

            }
        }
    }
}