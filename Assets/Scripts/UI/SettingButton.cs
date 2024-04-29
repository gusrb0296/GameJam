using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] GameObject SettingPanel;


    private void Start()
    {
        button.onClick.AddListener(OnPanel);
    }

    private void OnPanel()
    {
        SettingPanel.SetActive(true);
    }
}
