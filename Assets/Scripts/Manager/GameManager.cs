using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public FadeInOut fadePanel;
    public SceneController sceneManager;

    public UnityEvent<int, int> GetIngredient;

    public UnityEvent TriggerOff;

    public UnityEvent<int> GetTypesIngredient;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }


    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            fadePanel.StartFadeIn();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            fadePanel.StartFadeOut();
        }
    }

    public void GameOver()
    {
        print("게임 메니저 게임 오버");
        GameObject gamaPanel = GameObject.FindWithTag("GameCanvas");
        gamaPanel.GetComponent<GameCanvas>().GameOver();

    }
}
