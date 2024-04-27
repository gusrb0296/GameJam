using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI text_Gold;

    [SerializeField] Button btn_Pause;

    [SerializeField] Button panel_Dim;

    [SerializeField] GameObject panel_Pause;

    bool isPause;

    private int currentGold;

    private void Start()
    {
        isPause = false;
        btn_Pause.onClick.AddListener(PuaseToggle);
        panel_Dim.onClick.AddListener(PuaseToggle);

        currentGold = 0;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PuaseToggle();
            return;
        }
    }

    private void PuaseToggle()
    {
        if (isPause)
        {
            print("게임 재개");
            panel_Pause.SetActive(false);
            panel_Dim.gameObject.SetActive(false);

            Time.timeScale = 1;
            isPause = false;

            return;
        }
        else
        {
            print("게임 정지");
            panel_Pause.SetActive(true);
            panel_Dim.gameObject.SetActive(true);

            Time.timeScale = 0;
            isPause = true;

            return;
        }
    }

    public void SetGold(int gold)
    {
        currentGold += gold;
        text_Gold.text = currentGold.ToString();
    }
}
