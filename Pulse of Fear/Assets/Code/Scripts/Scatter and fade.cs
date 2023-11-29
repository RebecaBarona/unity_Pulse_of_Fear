using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scatterandfade : MonoBehaviour
{
    public float scatterIntensity = 1.0f;
    public float fadeDuration = 2.0f;

    private TextMeshProUGUI textMesh;
    private Material textMaterial;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMaterial = textMesh.material;

        StartCoroutine(ScatterAndFadeLetters());
    }

    IEnumerator ScatterAndFadeLetters()
    {
        float startTime = Time.time;
        Color originalColor = textMaterial.color;

        while (Time.time - startTime < fadeDuration)
        {
            float progress = (Time.time - startTime) / fadeDuration;
            Color fadedColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1.0f - progress);

            textMaterial.color = fadedColor;

            yield return null;
        }

        textMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.0f);
    }
}
