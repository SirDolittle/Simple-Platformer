using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerDisplay;
    public DataCollection dataCollection;

    private void Start()
    { 
    }

    private void Update()
    {
        float time = Time.timeSinceLevelLoad + dataCollection.lastLevelTime;
        timerDisplay.text = time.ToString();  
    }
}
