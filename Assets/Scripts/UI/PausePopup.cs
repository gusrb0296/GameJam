using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePopup : MonoBehaviour
{
    [SerializeField] GameObject pausePopUp;
    [SerializeField] Button btn_Recipe;

    private void Start()
    {
        btn_Recipe.onClick.AddListener(OpenPopUp);
    }

    private void OpenPopUp()
    {
        pausePopUp.SetActive(true);


    }

}
