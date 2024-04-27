using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickable : MonoBehaviour
{
    [SerializeField] int gold;

    [SerializeField] GameObject floatTextPrefab;

    Vector3 upperPivot = new Vector3(0, 1.0f , 0);

    GameObject gameCanvas;
        
    private void Start()
    {
        gameCanvas = GameObject.FindWithTag("GameCanvas");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cheese")
        {
            print($"트리거 들어옴 : {other.gameObject.name}");
            gameObject.transform.parent = other.transform;

            gameCanvas.GetComponent<GameCanvas>().SetGold(gold);

            GameObject go = Instantiate(floatTextPrefab);
            go.transform.position = transform.position + upperPivot;
            go.GetComponent<FloatingText>().Initialize(gold);
        }
    }
}
