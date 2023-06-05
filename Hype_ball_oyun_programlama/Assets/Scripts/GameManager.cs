using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManagerr uimanager;

    public interstitial interstitial;
    public rewarded rewarded;
    public void Start()
    {
        Coin(0);
        Debug.Log(PlayerPrefs.GetInt("money"));
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")&& gameObject.CompareTag("Finish_line"))
        {
            Debug.Log("Game over");
            if(PlayerPrefs.HasKey("NoAds") && PlayerPrefs.GetInt("NoAds") == 0)
            {
                interstitial.LoadAd();
            }
           
            rewarded.LoadAd();
            Coin(100);
            uimanager.CoinTextUpdate();
            uimanager.FinishScreen();
            PlayerPrefs.SetInt("LevelIndex", PlayerPrefs.GetInt("LevelIndex") + 1);
        }
    }




    public void Coin(int money)
    {
        if (PlayerPrefs.HasKey("moneyy"))
        {
            int oldScore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy", oldScore+money);
        }
        else
        {
            PlayerPrefs.SetInt("moneyy", 50000);
        }
    }

}
