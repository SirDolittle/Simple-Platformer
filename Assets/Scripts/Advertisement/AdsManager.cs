using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour
{

    string gameId = "1234567";
    bool testMode = true;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowAdvert()
    {
        Advertisement.Show();
    }
}
