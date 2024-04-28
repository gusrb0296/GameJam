using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    private bool[] checkbox = new bool[8];
    int count = 0;

    bool isEntered;

    private void Start()
    {
        GameManager.Instance.GetTypesIngredient.AddListener(CheckonCheckBox);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cheese") && !isEntered)
        {
            isEntered = true;

            print("�Ϸ�!");
            WinCheck();
            collision.GetComponentInParent<shootCheese>().enabled = false;
            collision.GetComponentInParent<softbody>().CheckMoveToDish();
        }
    }

    private void CheckonCheckBox(int index)
    {
        if (!checkbox[index])
        {
            checkbox[index] = true;
            count++;
        }
    }

    private void WinCheck()
    {
        if (checkbox[0] && checkbox[1] && checkbox[2] && count == 3)
        {
            print("������(1) �丶�� �Ľ�Ÿ �ϼ�");
            int isPasterDone = PlayerPrefs.GetInt("Paster", 0);
            if (isPasterDone == 0)
            {

            }
            PlayerPrefs.SetInt("Paster", 1);
        }
        else if (checkbox[0] && checkbox[3] && checkbox[4] && count == 3)
        {
            print("������(2) �丶�� ������ �ϼ�");
            int isSaladaDone = PlayerPrefs.GetInt("Salada", 0);
            if (isSaladaDone == 0)
            {

            }
            PlayerPrefs.SetInt("Salada", 1);

        }
        else if (checkbox[6] && checkbox[5] && checkbox[2] && count == 3)
        {
            print("������(3) ��� �佺Ʈ �ϼ�");

            int isToastDone = PlayerPrefs.GetInt("Toast", 0);
            if (isToastDone == 0)
            {

            }
            PlayerPrefs.SetInt("Toast", 1);
        }
        else  if (checkbox[3] && checkbox[6] && checkbox[7] && count == 3)
        {
            print("������(2) ��� ī���� �ϼ�");
            int isCanapeDone = PlayerPrefs.GetInt("Toast", 0);
            if(isCanapeDone == 0)
            {

            }
            PlayerPrefs.SetInt("Canape", 1);
        }
        else
        {
            print("�����Ǹ� �ϼ����� ����");
        }
    }
}
