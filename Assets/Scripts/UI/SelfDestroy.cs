using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] Button closeButton;

    void Start()
    {
        closeButton.onClick.AddListener(OnSelfDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSelfDestroy()
    {
        Destroy(gameObject);
    }
}
