using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/DataCollection", order = 1)]
public class DataCollection : ScriptableObject
{
    public float LevelCompletionTime;
    public float LevelDeathCount;
    public float HealthPacksPickedUp; 

    // Start is called before the first frame update
    void Start()
    {
        LevelCompletionTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
