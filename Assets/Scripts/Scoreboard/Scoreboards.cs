using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 

namespace Noah.Scoreboards
{
    
    public class Scoreboards : MonoBehaviour
    {
        [SerializeField] private int maxScoreBoardEntries = 10;
        [SerializeField] private Transform highscoresHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;
        [SerializeField] ScoreboardEntryData testEntryData = new ScoreboardEntryData();
        [SerializeField] public DataCollection dataCollection; 
        private string SavePath => $"{Application.persistentDataPath}/highscores.json";

        private void Start()
        {
            ScoreboardSaveData savedScores = GetSavedScores();

            SaveScores(savedScores);

            UpdateUI(savedScores);

            AddEntry(dataCollection.newEntry);
        }

        [ContextMenu("Add player test")]
        private void AddTestEntry()
        {
            AddEntry(testEntryData); 
        }


        public void AddEntry(ScoreboardEntryData scoreboardEntryData)
        {
            ScoreboardSaveData savedScores = GetSavedScores();
            bool scoreAdded = false;

            for(int i = 0; i <savedScores.highscores.Count; i++)
            {
                if(scoreboardEntryData.entryTime < savedScores.highscores[i].entryTime)
                {
                    savedScores.highscores.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break; 
                }
            }

            if(!scoreAdded && savedScores.highscores.Count < maxScoreBoardEntries)
            {
                savedScores.highscores.Add(scoreboardEntryData); 
            }

            if(savedScores.highscores.Count > maxScoreBoardEntries)
            {
                savedScores.highscores.RemoveRange(maxScoreBoardEntries, savedScores.highscores.Count - maxScoreBoardEntries); 
            }

            dataCollection.newEntry = scoreboardEntryData;

            UpdateUI(savedScores);
            SaveScores(savedScores); 
        }

        public void UpdateUI(ScoreboardSaveData savedScores)
        {
            foreach(Transform child in highscoresHolderTransform)
            {
                Object.Destroy(child.gameObject);
            }
            foreach (ScoreboardEntryData highscore in savedScores.highscores)
            {
                Instantiate(scoreboardEntryObject, highscoresHolderTransform).GetComponent<ScoreboardEntryUI>().Initialise(highscore); 
            }
        }
        public ScoreboardSaveData GetSavedScores()
        {
            if(!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();

                return new ScoreboardSaveData(); 
            }

            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<ScoreboardSaveData>(json); 
            }

        }

        public void SaveScores(ScoreboardSaveData scoreboardSaveData)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true);
                stream.Write(json); 
            }
        }

        private void OnApplicationQuit()
        {
            dataCollection.LevelCompletionTime = 0;
            dataCollection.LevelDeathCount = 0;
            dataCollection.HealthPacksPickedUp = 0;
            dataCollection.TotalTimeInGame = 0;
            dataCollection.lastLevelTime = 0;
        }


    }

}
