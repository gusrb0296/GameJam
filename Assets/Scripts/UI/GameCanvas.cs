using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text_Gold;

    [SerializeField] Button btn_Pause;

    [SerializeField] GameObject panel_Pause;

    bool isPause;

    private void Start()
    {
        isPause = false;
        btn_Pause.onClick.AddListener(PuaseToggle);
    }


    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            PuaseToggle();
        }
    }

    private void PuaseToggle()
    {
        if (isPause)
        {
            print("게임 재개");
            panel_Pause.SetActive(false);

            Time.timeScale = 1;
            isPause = true;
        }
        else
        {
            print("게임 정지");
            panel_Pause.SetActive(true);

            Time.timeScale = 0;
            isPause = false;
        }
    }
}
