using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HighScoreBoard : MonoBehaviour
{
    private Transform entrycontainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entrycontainer = transform.Find("HighScoreContainer");
        entryTemplate = entrycontainer.Find("HighScoreTemplate");
 

        entryTemplate.gameObject.SetActive(false);


        highscoreEntryList = new List<HighscoreEntry>();
    


        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for(int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if(highscoreEntryList[j].score < highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp; 
                }
            }
        }


        highscoreEntryTransformList = new List<Transform>();
        foreach(HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entrycontainer, highscoreEntryTransformList);
        }

    }


    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 50f;
        Transform entryTransform = Instantiate(entryTemplate, entrycontainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("Position").GetComponent<Text>().text = rankString;
        float score = highscoreEntry.score; 
        entryTransform.Find("Time").GetComponent<Text>().text = score.ToString();
        string name = highscoreEntry.name; 
        entryTransform.Find("Name").GetComponent<Text>().text = name;

        transformList.Add(entryTransform); 
    }


    public class HighscoreEntry
    {
        public float score;
        public string name; 
    }
}

