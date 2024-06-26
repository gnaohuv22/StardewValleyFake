using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTint : MonoBehaviour
{
    [SerializeField]
    Color unTintedColor;
    [SerializeField]
    Color tintedColor;
    public float speed = 0.5f;
    Image image;
    float f;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Tint()
    {
        StopAllCoroutines();
        f = 0f;
        StartCoroutine(TintScreen());
    }

    public void unTint()
    {
        StopAllCoroutines(); 
        f = 0f;
        StartCoroutine(UnTintScreen());
    }

    private IEnumerator TintScreen()
    {
        while (f < 1f)
        {
f += Time.deltaTime * speed;
        f = Mathf.Clamp(f, 0, 1f);
        Color c = image.color;
        c = Color.Lerp(unTintedColor, tintedColor, f);
            image.color = c;
            yield return new WaitForSeconds(f);
        }
        unTint();
    }

    private IEnumerator UnTintScreen()
    {
        while (f < 1f)
        {
            f += Time.deltaTime * speed;
            f = Mathf.Clamp(f, 0, 1f);
            Color c = image.color;
            c = Color.Lerp(unTintedColor, tintedColor, f);
            image.color = c;
            yield return new WaitForSeconds(f);
        }

    }
}
