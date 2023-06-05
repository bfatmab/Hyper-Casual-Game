using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public UIManagerr managerr; 

    public GameObject partical1;
    public GameObject partical2;
    public GameObject partical3;
    public GameObject partical4;

    public Sprite yellowImage;
    public Sprite greenImage;

    public GameObject Item;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;

    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;

    public void Awake()
    {

        if (PlayerPrefs.HasKey("itemselect") == false)
            PlayerPrefs.SetInt("itemselect", 0);
        //**********item select*******
        if (PlayerPrefs.GetInt("itemselect") == 0)
            Item1Open();

        else if (PlayerPrefs.GetInt("itemselect") == 1)
            Item2Open();

       else  if (PlayerPrefs.GetInt("itemselect") == 2)
            Item3Open();

       else if (PlayerPrefs.GetInt("itemselect") == 3)
            Item4Open();




        //*************locks*************
        if (PlayerPrefs.HasKey("lock1Control")==false) ;
        PlayerPrefs.SetInt("lock1Control", 0);

        if (PlayerPrefs.HasKey("lock2Control")==false) ;
        PlayerPrefs.SetInt("lock2Control", 0);

        if (PlayerPrefs.HasKey("lock3Control") == false) ;
        PlayerPrefs.SetInt("lock3Control", 0);


        if(PlayerPrefs.GetInt("lock1Control")==1)
            lock1.SetActive(false);

        if (PlayerPrefs.GetInt("lock2Control") == 1)
            lock2.SetActive(false);

        if (PlayerPrefs.GetInt("lock3Control") == 1)
            lock3.SetActive(false);


    }




    public void Item1Open()
    {
        partical1.SetActive(true);
        partical2.SetActive(false);
        partical3.SetActive(false);
        partical4.SetActive(false);

        Item.GetComponent<Image>().sprite = greenImage;
        Item2.GetComponent<Image>().sprite = yellowImage;
        Item3.GetComponent<Image>().sprite = yellowImage;
        Item4.GetComponent<Image>().sprite = yellowImage;
        PlayerPrefs.SetInt("itemselect", 0);
    }

    public void Item2Open()
    {
        partical1.SetActive(false);
        partical2.SetActive(true);
        partical3.SetActive(false);
        partical4.SetActive(false);

        Item.GetComponent<Image>().sprite = yellowImage;
        Item2.GetComponent<Image>().sprite = greenImage;
        Item3.GetComponent<Image>().sprite = yellowImage;
        Item4.GetComponent<Image>().sprite = yellowImage;
        PlayerPrefs.SetInt("itemselect", 1);
    }



    public void Item3Open()
    {
        partical1.SetActive(false);
        partical2.SetActive(false);
        partical3.SetActive(true);
        partical4.SetActive(false);

        Item.GetComponent<Image>().sprite = yellowImage;
        Item2.GetComponent<Image>().sprite = yellowImage;
        Item3.GetComponent<Image>().sprite = greenImage;
        Item4.GetComponent<Image>().sprite = yellowImage;
        PlayerPrefs.SetInt("itemselect", 2);
    }

    

    public void Item4Open()
    {
        partical1.SetActive(false);
        partical2.SetActive(false);
        partical3.SetActive(false);
        partical4.SetActive(true);

        Item.GetComponent<Image>().sprite = yellowImage;
        Item2.GetComponent<Image>().sprite = yellowImage;
        Item3.GetComponent<Image>().sprite = yellowImage;
        Item4.GetComponent<Image>().sprite = greenImage;
        PlayerPrefs.SetInt("itemselect", 3);
    }



    //********Locks********


    public void LockOpen()
    {
        int money = PlayerPrefs.GetInt("moneyy");
        int lock1Control = PlayerPrefs.GetInt("lock1Control");
        if (money >= 2000 && lock1Control==0)
        {
            lock1.SetActive(false);
            PlayerPrefs.SetInt("moneyy",money-2000);
            PlayerPrefs.SetInt("lock1Control",1);
            Item2Open();
            managerr.CoinTextUpdate();
        }
    }

    public void Lock2Open()
    {
        int money = PlayerPrefs.GetInt("moneyy");
        int lock2Control = PlayerPrefs.GetInt("lock2Control");
        if (money >= 5000 && lock2Control == 0)
        {
            lock2.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 5000);
            PlayerPrefs.SetInt("lock2Control", 1);
            Item3Open();
            managerr.CoinTextUpdate();
        }
    }

    public void Lock3Open()
    {
        int money = PlayerPrefs.GetInt("moneyy");
        int lock3Control = PlayerPrefs.GetInt("lock3Control");
        if (money >= 10000 && lock3Control == 0)
        {
            lock3.SetActive(false);
            PlayerPrefs.SetInt("moneyy", money - 10000);
            PlayerPrefs.SetInt("lock3Control", 1);
            Item4Open();
            managerr.CoinTextUpdate();
        }
    }



}
