using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public FadeInOut fadePanel;

    public UnityEvent GoldUpdate;

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
        if(Input.GetKeyDown(KeyCode.V)) 
        {
            fadePanel.StartFadeIn();
        }

        if(Input.GetKeyDown(KeyCode.B)) 
        {
            fadePanel.StartFadeOut();
        }
    }
}
