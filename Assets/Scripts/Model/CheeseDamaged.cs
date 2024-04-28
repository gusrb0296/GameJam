using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheeseDamaged : MonoBehaviour
{
    int HP = 3;

    [SerializeField] GameCanvas gameCanvas;

    [SerializeField] HeartFade[] HPs;

    [SerializeField] softbody cheese;

    [SerializeField] GameObject gamePanel;

    [SerializeField] GameObject dim_panel;

    [SerializeField] GameObject angryCrab;
    [SerializeField] GameObject happyCrab;

    [SerializeField] GameObject[] unlockedRecipes;

    [SerializeField] GameObject one;
    [SerializeField] GameObject two;

    Collider2D thisCollider2D;

    bool isEnter=false;

    int count = 0;

    private bool[] checkbox = new bool[8];

    private void Start()
    {
        thisCollider2D = GetComponent<Collider2D>();

        GameManager.Instance.GetTypesIngredient.AddListener(CheckonCheckBox);
    }

    private void CheckonCheckBox(int index)
    {
        if (!checkbox[index])
        {
            checkbox[index] = true;
            count++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Crab")
        {
            

            if (cheese.IsFinish && !isEnter)
            {

                isEnter = true;

                WinCheck();
                //gamePanel.SetActive(false);
                //GameManager.Instance.fadePanel.StartFadeOut();
                dim_panel.SetActive(true);
                CircleCollider2D collider = GetComponent<CircleCollider2D>();
                collider.enabled = false;
               

                return;
            }
            else if(!cheese.IsFinish)
            {
                Vector2 direction = transform.position - collision.transform.position;
                cheese.GetComponent<shootCheese>().rb.velocity = direction.normalized * 25f;

                if (HP > 0) HPs[HP - 1].SetHeartFade();
                HP--;
                print($"ġ� �ǰݴ���. HP : {HP}");

                if (HP == 0)
                {
                    print("GameOver");
                    GameManager.Instance.GameOver();
                }
            }
        }
    }

    private void WinCheck()
    {
        one.SetActive(true);
        two.SetActive(true);
        if (checkbox[0] && checkbox[1] && checkbox[2] && count == 3)
        {
            print("������(1) �丶�� �Ľ�Ÿ �ϼ�");
            int isPasterDone = PlayerPrefs.GetInt("Paster", 0);
            if (isPasterDone == 0)
            {
                Recipe(0);
                HappyCrab();
            }
            PlayerPrefs.SetInt("Paster", 1);
        }
        else if (checkbox[0] && checkbox[3] && checkbox[4] && count == 3)
        {
            print("������(2) �丶�� ������ �ϼ�");
            int isSaladaDone = PlayerPrefs.GetInt("Salada", 0);
            if (isSaladaDone == 0)
            {
                Recipe(1);
                HappyCrab();
            }
            PlayerPrefs.SetInt("Salada", 1);

        }
        else if (checkbox[6] && checkbox[5] && checkbox[2] && count == 3)
        {
            print("������(3) ��� �佺Ʈ �ϼ�");

            int isToastDone = PlayerPrefs.GetInt("Toast", 0);
            if (isToastDone == 0)
            {
                Recipe(2);
                HappyCrab();
            }
            PlayerPrefs.SetInt("Toast", 1);
        }
        else if (checkbox[3] && checkbox[6] && checkbox[7] && count == 3)
        {
            print("������(2) ��� ī���� �ϼ�");
            int isCanapeDone = PlayerPrefs.GetInt("Toast", 0);
            if (isCanapeDone == 0)
            {
                Recipe(3);
                HappyCrab();
            }
            PlayerPrefs.SetInt("Canape", 1);
        }
        else
        {
            print("�����Ǹ� �ϼ����� ����");
            AngryCrab();
        }
    }

    private void HappyCrab()
    {
        Instantiate(happyCrab, new Vector3(19.22f, 0, 0), Quaternion.identity);
    }

    private void AngryCrab()
    {
        Instantiate(angryCrab, new Vector3(19.22f, 0, 0), Quaternion.identity);
    }

    private void Recipe(int index)
    {
        GameObject go = Instantiate(unlockedRecipes[index], new Vector3(965, 525, 0), Quaternion.identity);
        go.transform.parent = gameCanvas.transform;
    }
}
