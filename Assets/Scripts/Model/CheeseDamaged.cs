using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseDamaged : MonoBehaviour
{
    int HP = 3;

    [SerializeField] GameCanvas gameCanvas;

    [SerializeField] HeartFade[] HPs;

    [SerializeField] softbody cheese;

    [SerializeField] GameObject gamePanel;

    Collider2D thisCollider2D;

    bool isEnter=false;

    private void Start()
    {
        thisCollider2D = GetComponent<Collider2D>();

        print($"치즈의 콜라이더의 태그 : {thisCollider2D.tag}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Crab")
        {
            

            if (cheese.IsFinish && !isEnter)
            {

                isEnter = true;
                gamePanel.SetActive(false);
                GameManager.Instance.fadePanel.StartFadeOut();
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
                print($"치즈가 피격당함. HP : {HP}");

                if (HP == 0)
                {
                    print("GameOver");
                    GameManager.Instance.GameOver();
                }
            }
        }
    }
}
