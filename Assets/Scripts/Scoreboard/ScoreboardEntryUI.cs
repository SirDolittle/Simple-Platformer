using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System; 

namespace Noah.Scoreboards
{
    public class ScoreboardEntryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI entryNameText = null;
        [SerializeField] private TextMeshProUGUI entryTimeText = null;


        public void Initialise(ScoreboardEntryData scoreboardEntryData)
        {
            entryNameText.text = scoreboardEntryData.entryName;
            entryTimeText.text = scoreboardEntryData.entryTime.ToString();
        }

    }

}