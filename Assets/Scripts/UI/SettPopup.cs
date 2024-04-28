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
    [SerializeField] Sprite soundYes;
    [SerializeField] Sprite soundNo;
    private float rememberB;
    private float rememberS;

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
            SoundManager.Instance.SetVolumeBGM(rememberB);
            btn_muteBGM.GetComponent<Image>().sprite = soundYes;
            lockBGM = false;
        }
        else
        {
            rememberB = slider_BGM.value;
            SoundManager.Instance.SetMuteBGM();
            btn_muteBGM.GetComponent<Image>().sprite = soundNo;
            lockBGM = true;
        }
    }
    private void mutesfx()
    {
        if (lockSFX)
        {
            SoundManager.Instance.SetVolumeSFX(rememberS);
            btn_muteSFX.GetComponent<Image>().sprite = soundYes;
            lockSFX = false;
        }
        else
        {
            rememberS = slider_SFX.value;
            SoundManager.Instance.SetMuteSFX();
            btn_muteSFX.GetComponent<Image>().sprite = soundNo;
            lockSFX = true;
        }
    }

    private void BGMslider_Changed(float value)
    {
        if (lockBGM)
        {
            slider_BGM.value = rememberB;
        }
        else
        {
            SoundManager.Instance.SetVolumeBGM(value);
        }

    }
    private void SFXslider_Changed(float value)
    {
        if (lockSFX)
        {
            slider_SFX.value = rememberS;
        }
        else
        {
            SoundManager.Instance.SetVolumeSFX(value);
        }

    }
}