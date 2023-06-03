using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManagerr uimanager;
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
            Coin(100);
            uimanager.CoinTextUpdate();
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
            PlayerPrefs.SetInt("moneyy", 0);
        }
    }

}
