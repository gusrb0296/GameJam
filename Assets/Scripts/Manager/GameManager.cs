using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FadeInOut fadePanel;

    public int Gold { get; set; }    

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

        Gold = 0;
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
