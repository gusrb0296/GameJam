using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    SpawnManager spawnManager;

    bool isSpawn = false;

    private bool IngredientCheckBox;

    public GameObject rangeObject;

    float coolTime = 15;

    private void Awake()
    {
        spawnManager = GetComponentInParent<SpawnManager>();
    }

}
