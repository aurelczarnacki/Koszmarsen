using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageBlinking : MonoBehaviour
{
    public float blinkSpeed = 1.0f;
    private Image imageComponent;
    Color startColor;
    Color targetColor;

    private void Start()
    {      
        imageComponent = GetComponent<Image>();
        startColor = imageComponent.color;
    }
    private void Update()
    {
            StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        Color targetcolor  = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (true)
        {
            float t = Mathf.PingPong(Time.time * blinkSpeed, 1f) / 1f;
            imageComponent.color = Color.Lerp(startColor, targetColor, t);

            yield return null;
        }
    }
}