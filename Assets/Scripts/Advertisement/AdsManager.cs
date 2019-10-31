using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour, IUnityAdsListener
{

    string gameId = "3325204";
     
    bool testMode = true;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }

    
   public void OnUnityAdsDidFinish(string placementId, ShowResult showresult)
    {

    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string placementId)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }


    public void ShowAdvert()
    {
        Advertisement.Show();
    }
}
