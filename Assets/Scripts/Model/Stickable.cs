using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickable : MonoBehaviour
{
    [SerializeField] int gold;

    [SerializeField] GameObject floatTextPrefab;

    Vector3 upperPivot = new Vector3(0, 1.0f , 0);

    private void OnTriggerEnter2D(Collider2D other)
    {
        print($"트리거 들어옴 : {other.gameObject.name}");
        gameObject.transform.parent = other.transform;

        GameManager.Instance.Gold += gold;

        GameObject go = Instantiate(floatTextPrefab);
        go.transform.position = transform.position + upperPivot;
        go.GetComponent<FloatingText>().Initialize();
        go.GetComponent<FloatingText>().SetGold(gold);
    }
}
