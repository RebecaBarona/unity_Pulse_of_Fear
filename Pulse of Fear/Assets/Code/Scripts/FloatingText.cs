using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class FloatingText : MonoBehaviour
{

    [SerializeField] GameObject Player;

    [Header("Text Porperties")]
    [SerializeField] TextMeshProUGUI floatingText;
    [SerializeField] string textContent;
    [SerializeField] Color textColor;
    [SerializeField] float textFadeAlpha;
    [SerializeField] float textStartAlpha;

    [Header("Audio properties")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip; 

   [SerializeField] float  timer = 20;

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
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
      
        if(distance <= 2.5f)
        {     
            if (isFading && floatingText.color.a <= 0.0f)
            {
              
                isFading = false;
                floatingText.gameObject.SetActive(false);
            }
             else  if ((!isFading))
            {
                StartFade();
            }
        }
        else if(audioClip != null)
        {
            if (!audioSource.isPlaying)
            {
                if (isFading && floatingText.color.a <= 0.0f)
                {
                    //Debug.Log("Text fading is complete!");
                    isFading = false;
                    floatingText.gameObject.SetActive(false);
                }
                else if ((!isFading))
                {
                    StartFade();
                }
            }
        }
    }

    private void StartFade()
    {
        isFading = true; 


        Color initialColor = floatingText.color;
        initialColor.a = 1.0f;
        floatingText.color = initialColor;

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
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            Color newColor = startColor;
            newColor.a = alpha;
            floatingText.color = newColor;

            yield return null;
        }

      
        Color finalColor = startColor;
        finalColor.a = 0f;
        floatingText.color = finalColor;

        isFading = false; 
    }
}

