using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI text_Gold;

    [SerializeField] Button btn_Pause;

    [SerializeField] Button panel_Dim;

    [SerializeField] GameObject panel_Pause;

    [SerializeField] GameObject gameOverPivot;

    [SerializeField] Image[] ingredients;

    [SerializeField] Button btn_Lobby;

    [SerializeField] Button btn_Recipe;

    [SerializeField] Button btn_Back;

    [SerializeField] Button btn_replay;

    [SerializeField] Button btn_BackToLobby;


    Color colored = new Color(1, 1, 1, 1);

    bool isPause;

    private int currentGold;

    private void Start()
    {
        isPause = false;
        btn_Pause.onClick.AddListener(PauseToggle);
        panel_Dim.onClick.AddListener(PauseToggle);
        btn_Back.onClick.AddListener(PauseToggle);
        btn_Lobby.onClick.AddListener(MoveToLobby);
        btn_Recipe.onClick.AddListener(OpenRecipePanel);

        btn_BackToLobby.onClick.AddListener(Lobbybtn);
        btn_replay.onClick.AddListener(Replaybtn);

        GameManager.Instance.GetTypesIngredient.AddListener(SetIngredientColored);

        currentGold = 0;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseToggle();
            return;
        }
    }

    private void PauseToggle()
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
        if(currentGold >= 30000)
        {
            GameManager.Instance.TriggerOff.Invoke();
        }
        text_Gold.text = currentGold.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        gameOverPivot.SetActive(true);
    }

    private void SetIngredientColored(int index)
    {
        ingredients[index].color = colored;
    }

    private void MoveToLobby()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LobbyScene");
    }

    private void OpenRecipePanel()
    {

    }

    private void Replaybtn()
    {
        SceneManager.LoadScene("KHK_Scene");
    }

    private void Lobbybtn()
    {
        SceneManager.LoadScene("Lobby_Scene");
    }
}
