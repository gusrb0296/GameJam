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
        print($"�浹 ���� : {collision.gameObject.name}");
        if (collision.transform.CompareTag("Point"))
        {
            GameObject go = Instantiate(alertText);
            go.transform.position = transform.position;
            go.GetComponent<FloatingAlert>().Initialize();
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger) // if 30000 is filled
    {
        if (trigger.transform.CompareTag("Cheese"))
        {
            Debug.Log("ending");
        }
    }

}
