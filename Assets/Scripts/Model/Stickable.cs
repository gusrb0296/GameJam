using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickable : MonoBehaviour
{
    [SerializeField] int gold;

    [SerializeField] GameObject floatTextPrefab;

    Vector3 upperPivot = new Vector3(0, 1.25f , 0);

    GameObject gameCanvas;

    public int pivotIndex;

        
    private void Start()
    {
        gameCanvas = GameObject.FindWithTag("GameCanvas");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cheese"))
        {
            gameObject.transform.parent = other.transform;

            gameCanvas.GetComponent<GameCanvas>().SetGold(gold);

            GameObject go = Instantiate(floatTextPrefab);
            go.transform.position = transform.position + upperPivot;
            go.GetComponent<FloatingText>().Initialize(gold);

            Invoke("SpawnWithEvent", 10f);            
        }
    }

    private void SpawnWithEvent()
    {
        int rand = Random.Range(0, 16);
        GameManager.Instance.GetIngredient.Invoke(rand, pivotIndex);
    }
}
