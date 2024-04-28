using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyCanvas : MonoBehaviour
{
    [SerializeField] Button btn_Start;
    [SerializeField] Button btn_Recipe;
    [SerializeField] Button btn_Tutorial;
    [SerializeField] Button btn_Setting;

    [SerializeField] GameObject panel_recipe;
    [SerializeField] GameObject panel_tutorial;
    [SerializeField] GameObject panel_setting;

    void Start()
    {
        btn_Start.onClick.AddListener(MoveMainScene);
        btn_Recipe.onClick.AddListener(RecipePop);
        btn_Tutorial.onClick.AddListener(Tutorial);
        btn_Setting.onClick.AddListener(SettingPop);
        SoundManager.Instance.PlayBGM(2);
    }
    private void MoveMainScene()
    {
        SceneManager.LoadScene("KHK_Scene");
    }

    private void RecipePop()
    {
        SoundManager.Instance.PlaySFX(3);
        panel_recipe.SetActive(true);
    }

    private void Tutorial()
    {
        SoundManager.Instance.PlaySFX(3);
        panel_tutorial.SetActive(true);
    }

    private void SettingPop()
    {
        SoundManager.Instance.PlaySFX(3);
        panel_setting.SetActive(true);
    }
}
