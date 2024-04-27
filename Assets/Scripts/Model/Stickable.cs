using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickable : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        print($"트리거 들어옴 : {other.gameObject.name}");
        gameObject.transform.parent = other.transform;
    }
}
