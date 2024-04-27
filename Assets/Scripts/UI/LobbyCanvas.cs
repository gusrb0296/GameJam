using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyCanvas : MonoBehaviour
{
    public Button btn_Start;
    public Button btn_Recipe;
    public Button btn_Setting;

    void Start()
    {
        btn_Start.onClick.AddListener(MoveMainScene);
        //btn_Recipe.onClick.AddListener( );
        //btn_Setting.onClick.AddListener( );
    }
    private void MoveMainScene()
    {
        SceneManager.LoadScene("KHK_Scene");
    }
}
