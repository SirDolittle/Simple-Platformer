using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : Singleton<DataManager>
{
    public Text goldCountText;
    private int goldCount = 0;
    private bool episodeOne = false;
    public GameObject episodeOneButton;
    public void BuyGold(int _amount)
    {
        goldCount += _amount;
        goldCountText.text = goldCount.ToString();
    }
    public void BuyEpisodeOne()
    {
        episodeOne = true;
        episodeOneButton.SetActive(false);
    }
}
