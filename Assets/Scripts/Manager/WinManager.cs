using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] GameObject angryCrab;
    [SerializeField] GameObject happyCrab;

    [SerializeField] GameObject[] unlockedRecipes;

    [SerializeField] 

    private bool[] checkbox = new bool[8];

    bool isEntered;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cheese") && !isEntered)
        {
            isEntered = true;

            print("�Ϸ�!");
            //WinCheck();
            collision.GetComponentInParent<shootCheese>().enabled = false;
            collision.GetComponentInParent<softbody>().CheckMoveToDish();
        }
    }



    //private void WinCheck()
    //{
    //    if (checkbox[0] && checkbox[1] && checkbox[2] && count == 3)
    //    {
    //        print("������(1) �丶�� �Ľ�Ÿ �ϼ�");
    //        int isPasterDone = PlayerPrefs.GetInt("Paster", 0);
    //        if (isPasterDone == 0)
    //        {
    //            StartCoroutine(Recipe(0));
    //            StartCoroutine(HappyCrab());
    //        }
    //        PlayerPrefs.SetInt("Paster", 1);
    //    }
    //    else if (checkbox[0] && checkbox[3] && checkbox[4] && count == 3)
    //    {
    //        print("������(2) �丶�� ������ �ϼ�");
    //        int isSaladaDone = PlayerPrefs.GetInt("Salada", 0);
    //        if (isSaladaDone == 0)
    //        {
    //            StartCoroutine(Recipe(1));
    //            StartCoroutine(HappyCrab());
    //        }
    //        PlayerPrefs.SetInt("Salada", 1);

    //    }
    //    else if (checkbox[6] && checkbox[5] && checkbox[2] && count == 3)
    //    {
    //        print("������(3) ��� �佺Ʈ �ϼ�");

    //        int isToastDone = PlayerPrefs.GetInt("Toast", 0);
    //        if (isToastDone == 0)
    //        {
    //            StartCoroutine(Recipe(2));
    //            StartCoroutine(HappyCrab());
    //        }
    //        PlayerPrefs.SetInt("Toast", 1);
    //    }
    //    else if (checkbox[3] && checkbox[6] && checkbox[7] && count == 3)
    //    {
    //        print("������(2) ��� ī���� �ϼ�");
    //        int isCanapeDone = PlayerPrefs.GetInt("Toast", 0);
    //        if (isCanapeDone == 0)
    //        {

    //            StartCoroutine(Recipe(3));
    //            StartCoroutine(HappyCrab());
    //        }
    //        PlayerPrefs.SetInt("Canape", 1);
    //    }
    //    else
    //    {
    //        print("�����Ǹ� �ϼ����� ����");
    //    }
    //}

    IEnumerator HappyCrab() 
    {
        yield return new WaitForSeconds(1.25f);

        Instantiate(happyCrab, new Vector3(19.22f, 0, 0), Quaternion.identity);
    }

    IEnumerator Recipe(int index)
    {
        print("������ ������");
        yield return new WaitForSeconds(1f);
        GameObject go = Instantiate(unlockedRecipes[index], new Vector3(19.22f, 0, 0), Quaternion.identity);
        GameObject parent = GameObject.Find("GameManagerCanvas");
        go.transform.parent = parent.transform;
    }

    private void SpawnHappyCrab()
    {
        Instantiate(happyCrab, new Vector3(19.22f, 0, 0), Quaternion.identity);
    }

    private void SpawnAngryCrab()
    {
        Instantiate(happyCrab, new Vector3(19.22f, 0, 0), Quaternion.identity);
    }
}
