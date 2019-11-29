using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;

namespace Noah.Scoreboards
{
    [Serializable]

    public class ScoreboardSaveData
    {
        public List<ScoreboardEntryData> highscores = new List<ScoreboardEntryData>();
    }
}
