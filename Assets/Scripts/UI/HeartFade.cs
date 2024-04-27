using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartFade : MonoBehaviour
{
    Image imageHeart;

    Color fadeColor;

    private void Start()
    {
        imageHeart = GetComponent<Image>();

        fadeColor = new Color(1, 1, 1, 0.5f);
    }

    public void SetHeartFade()
    {
        imageHeart.color = fadeColor;
    }
}
