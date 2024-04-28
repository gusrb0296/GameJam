using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    SpawnManager spawnManager;

    public GameObject rangeObject;


    private void Awake()
    {
        spawnManager = GetComponentInParent<SpawnManager>();
    }

}
