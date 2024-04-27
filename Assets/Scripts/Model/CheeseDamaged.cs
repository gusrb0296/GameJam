using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseDamaged : MonoBehaviour
{
    int HP = 3;

    [SerializeField] GameCanvas gameCanvas;

    [SerializeField] HeartFade[] HPs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Crab")
        {
            HPs[HP - 1].SetHeartFade();
            HP--;
            print($"치즈가 피격당함. HP : {HP}");
            
            
            if(HP == 0)
            {
                print("GameOVer");
                GameManager.Instance.GameOver();
            }
        }
    }
}
