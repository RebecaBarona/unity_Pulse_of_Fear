using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallText : MonoBehaviour
{
    [SerializeField] GameObject Player;

    [Header("Text Properties")]
    [SerializeField] TextMeshProUGUI floatingText;
    [SerializeField] string textContent;
    [SerializeField] Color textColor;
    [SerializeField] float textStartAlpha;

    [Header("Audio Properties")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    [SerializeField] float timer = 20;
    public float fadeDuration;

    bool isFading = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        floatingText = GetComponentInChildren<TextMeshProUGUI>();
        floatingText.text = textContent;
        textColor = floatingText.color;
        textStartAlpha = textColor.a;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;

        // Set initial alpha to 0
        Color initialColor = floatingText.color;
        initialColor.a = 0f;
        floatingText.color = initialColor;
        floatingText.gameObject.SetActive(false); // Hide text initially
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance <= 5.5f)
        {
            if (!isFading && !floatingText.gameObject.activeSelf)
            {
                StartFade();
            }
        }
        else if (audioClip != null && !audioSource.isPlaying)
        {
            if (!isFading && !floatingText.gameObject.activeSelf)
            {
                StartFade();
            }
        }
    }

    private void StartFade()
    {
        isFading = true;
        floatingText.gameObject.SetActive(true); // Show text before fading

        StartCoroutine(FadeText());
    }

    private IEnumerator FadeText()
    {
        float startTime = Time.time;
        float elapsedTime = 0f;

        Color startColor = floatingText.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime = Time.time - startTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);

            Color newColor = startColor;
            newColor.a = alpha;
            floatingText.color = newColor;

            yield return null;
        }

        Color finalColor = startColor;
        finalColor.a = 1f;
        floatingText.color = finalColor;

        isFading = false;
    }
}