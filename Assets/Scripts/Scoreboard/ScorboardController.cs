using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Noah.Scoreboards;

namespace Noah.Scoreboards
{
    public class ScorboardController : MonoBehaviour
    {
        public Scoreboards scoreboards;
        [SerializeField] private Transform highscoresHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;
        private void Start()
        {
            ScoreboardSaveData savedScores = scoreboards.GetSavedScores();

            scoreboards.SaveScores(savedScores);

            scoreboards.UpdateUI(savedScores);
        }
    }
}
