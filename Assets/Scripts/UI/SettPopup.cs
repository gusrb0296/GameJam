using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettPopup : MonoBehaviour
{
    [SerializeField]
    Slider slider_BGM;
    private bool lockBGM = false;

    [SerializeField]
    Slider slider_SFX;
    private bool lockSFX = false;

    [SerializeField] Button btn_exit;
    [SerializeField] Button btn_muteBGM;
    [SerializeField] Button btn_muteSFX;


    void Start()
    {
        btn_exit.onClick.AddListener(exitSett);
        btn_muteBGM.onClick.AddListener(mutebgm);
        btn_muteSFX.onClick.AddListener(mutesfx);

        slider_BGM.onValueChanged.AddListener(BGMslider_Changed);
        slider_SFX.onValueChanged.AddListener(SFXslider_Changed);
    }

    private void exitSett()
    {
        gameObject.SetActive(false);
    }
    private void mutebgm()
    {
        if (lockBGM)
        {
            lockBGM = false;
            //change img of button
        }
        else
        {
            lockBGM = true;
            //
        }
    }
    private void mutesfx()
    {
        if (lockSFX)
        {
            lockSFX = false;
            //change img of button
        }
        else
        {
            lockSFX = true;
            //
        }
    }

    private void BGMslider_Changed(float value)
    {
        if (lockBGM)
        {
            slider_BGM.value = 0f;
        }

    }
    private void SFXslider_Changed(float value)
    {
        if (lockSFX)
        {
            slider_SFX.value = 0f;
        }

    }
}