using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManagerr : MonoBehaviour
{
    public Image whiteEffectImage;
    private int effectControl=0;
    private bool radialShine;

    public Animator LayoutAnimator;

    public Text coin_Text;

    public GameObject setting_open;
    public GameObject setting_close;
    public GameObject layout_Background;
    public GameObject sound_on;
    public GameObject sound_off;
    public GameObject vibration_on;
    public GameObject vibration_off;
    public GameObject iap;
    public GameObject information;
    public GameObject intro_hand;
    public GameObject toptomove_Text;
    public GameObject noAds;
    public GameObject shop;

    public GameObject Restart_screen;

    //Game en screen
    public GameObject finishScreen;
    public GameObject blackBackground;
    public GameObject complete;
    public GameObject radial_shine;
    public GameObject coin;
    public GameObject rewarded;
    public GameObject no_thanks;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if (PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }

        CoinTextUpdate();   

    }

    public void Update()
    {
        if (radialShine == true)
        {
            radial_shine.GetComponent<RectTransform>().Rotate(new Vector3(0,0, 15f * Time.deltaTime));
        }
    }


    public void CoinTextUpdate()
    {
        coin_Text.text = PlayerPrefs.GetInt("moneyy").ToString();
    }


    public void FirstTouch()
    {
        intro_hand.SetActive(false);
        toptomove_Text.SetActive(false);
        noAds.SetActive(false);
        shop.SetActive(false);
        setting_close.SetActive(false); 
        setting_open.SetActive(false);  
        layout_Background.SetActive(false);
        sound_off.SetActive(false);
        sound_on.SetActive(false);
        vibration_on.SetActive(!false);
        vibration_off.SetActive(!false);
        iap.SetActive(false);
        information.SetActive(false);
    }



    public void RestartButtonActive()
    {
        Restart_screen.SetActive(true);
    }

    public void RestartScene()
    {
        Variables.firsttouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


    public void FinishScreen()
    {
        StartCoroutine(FinishLaunch());

    }

    public IEnumerator FinishLaunch()
    {
        Time.timeScale = 0.5f;
        radialShine = true;
        finishScreen.SetActive(true);
        blackBackground.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        complete.SetActive(true);
        yield return new WaitForSecondsRealtime(1.3f);
        radial_shine.SetActive(true);
        coin.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        rewarded.SetActive(true);
        yield return new WaitForSecondsRealtime(3.5f);
        no_thanks.SetActive(true);



    }


    public void Privacy_Policy()
    {
        Application.OpenURL("https://sites.google.com/view/hypeballdash/privacy-police?authuser=1");
    }
    public void Term_of_use()
    {
        Application.OpenURL("https://sites.google.com/view/hypeballdash/term-of-use?authuser=1");
    }
   public void Setting_Open()
    {
        setting_open.SetActive(false);
        setting_close.SetActive(true);
        LayoutAnimator.SetTrigger("slide_in");

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_on.SetActive(true);
            sound_off.SetActive(false);
            AudioListener.volume = 1;
        }

        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_on.SetActive(false);
            sound_off.SetActive(true);
            AudioListener.volume = 0;
        }




         if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibration_off.SetActive(false);
            vibration_on.SetActive(true);
        }

        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibration_on.SetActive(false);
            vibration_off.SetActive(true);
        }

    }

    public void Setting_Close()
    {
        setting_close.SetActive(false);
        setting_open.SetActive(true);
        LayoutAnimator.SetTrigger("slide_out");
    }

    public void Sound_On()
    {
        sound_on.SetActive(false);
        sound_off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }

    public void Sound_Off()
    {
        sound_on.SetActive(true);
        sound_off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void Vibration_On()
    {
        vibration_on.SetActive(false);
        vibration_off.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }
    public void Vibration_Off()
    {
        vibration_off.SetActive(false);
        vibration_on.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 1);
    }

    //haskey
    //get
    //set


    public IEnumerator whiteEffect()
    {
        whiteEffectImage.gameObject.SetActive(true);
        while (effectControl==0)
        {


            yield return new WaitForSeconds(0.001f);
            whiteEffectImage.color += new Color(0,0,0,0.1f);
            if(whiteEffectImage.color==new Color(whiteEffectImage.color.r, whiteEffectImage.color.g, whiteEffectImage.color.b, 1))
            {
                effectControl = 1;
            }
        }

        while (effectControl == 1)
        {

            yield return new WaitForSeconds(0.001f);
            whiteEffectImage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r, whiteEffectImage.color.g, whiteEffectImage.color.b, 0))
            {
                effectControl = 2;
            }
        }
        if (effectControl == 2)
        {
            Debug.Log("efekt bitti.");
        }
       
    }
}
