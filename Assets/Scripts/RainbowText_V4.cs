using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class RainbowText_V4 : MonoBehaviour
{
    public float rainbowSpeed = 1f;
    private TextMeshProUGUI textMesh;
    private string originalText;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        originalText = textMesh.text;
    }

    void Update()
    {
        string rainbowText = "";

        for (int i = 0; i < originalText.Length; i++)
        {
            char currentChar = originalText[i];

            float hue = ((Time.time * rainbowSpeed) + i * 0.1f) % 1f;
            Color newColor = Color.HSVToRGB(hue, 1f, 1f);

            rainbowText += $"<color=#{ColorUtility.ToHtmlStringRGB(newColor)}>{currentChar}</color>";
        }

        textMesh.text = rainbowText;
    }
}