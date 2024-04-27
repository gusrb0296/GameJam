using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] Button btn_Exit;
    [SerializeField] Button btn_Retry;


    private void Start()
    {
        btn_Exit.onClick.AddListener(ToLobby); 
        btn_Retry.onClick.AddListener(RetryGame);
    }

    private void RetryGame()
    {
        //GameManager.Instance.sceneManager.LoadScene("KHK_Scene");
        SceneManager.LoadScene("KHK_Scene");
        Time.timeScale = 1;
    }

    private void ToLobby()
    {
        //GameManager.Instance.sceneManager.LoadScene("LobbyScene");
        SceneManager.LoadScene("LobbyScene");
        Time.timeScale = 1;
    }
}
