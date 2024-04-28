using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollider : MonoBehaviour
{
    CircleCollider2D circleCollider;

    [SerializeField] private GameObject alertText;


    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        GameManager.Instance.TriggerOff.AddListener(OffBlockTrigger);
    }

    private void OffBlockTrigger()
    {
        circleCollider.isTrigger = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print($"충돌 감지 : {collision.gameObject.name}");
        if(collision.transform.CompareTag("Point"))
        {
            GameObject go = Instantiate(alertText);
            go.transform.position = transform.position;
            go.GetComponent<FloatingAlert>().Initialize();
        }
    }

}
