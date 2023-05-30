using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerr : MonoBehaviour
{
    public Image whiteEffectImage;
    private int effectControl=0;

    public Animator LayoutAnimator;


    public GameObject setting_open;
    public GameObject setting_close;

    public GameObject sound_on;
    public GameObject sound_off;
    public GameObject vibration_on;
    public GameObject vibration_off;
    public GameObject iap;
    public GameObject information;

   public void Setting_Open()
    {
        setting_open.SetActive(false);
        setting_close.SetActive(true);
        LayoutAnimator.SetTrigger("slide_in");
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
    }

    public void Sound_Off()
    {
        sound_on.SetActive(true);
        sound_off.SetActive(false);
    }

    public void Vibration_On()
    {
        vibration_on.SetActive(false);
        vibration_off.SetActive(true);
    }
    public void Vibration_Off()
    {
        vibration_off.SetActive(false);
        vibration_on.SetActive(true);
    }




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
