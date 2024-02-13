using System.Collections;
using TMPro;
using UnityEngine;

public class WallTextDissolve : MonoBehaviour
{
    [SerializeField] GameObject player;

    [Header("Text Properties")]
    public float dissolveDuration = 3f;  // Duration for the dissolve effect
    public float initialDissolveAmount = 0f; // Initial dissolve amount
    public float finalDissolveAmount = 1f; // Final dissolve amount
    private SpriteRenderer spriteRenderer;
    private MaterialPropertyBlock materialPropertyBlock;
    private float dissolveTimer = 0f;
    public GameObject Triggercollider;
    public float DelayTimer = 5;
   
    public float fadeDuration;

    bool isFading = false;

    [SerializeField] float distanceRequired;
    [SerializeField] public PlayTextAudio playTextAudio;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        playTextAudio = GetComponentInChildren<PlayTextAudio>();
        if (spriteRenderer == null)
        {
          //  Debug.LogError("DissolveScript requires a SpriteRenderer component!");
            enabled = false;  // Disable the script if the required components are not present
        }
        if (playTextAudio == null)
        {
            Debug.LogError("PlayTextAudio component not found!");
        }

        materialPropertyBlock = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(materialPropertyBlock);

        // Set the initial value of _Alpha directly
        materialPropertyBlock.SetFloat("_Alpha", 0f);
        spriteRenderer.SetPropertyBlock(materialPropertyBlock);
    }


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        //  Debug.Log(distance);
        if (distance <= distanceRequired && playTextAudio.hasPlayed == true)
        {
          //  Debug.Log("playTextAudio.hasPlayed: " + playTextAudio.hasPlayed);
            // Additional logic if needed when player is within distance
            PlayDisappear();

        }

      //  Debug.Log(distance);
    }
    public void PlayDisappear()
    {
        StartCoroutine(AppearThenDisappear());
    }

    // Function to handle initial appearance and disappearance
    private IEnumerator AppearThenDisappear()
    {
        // Initial alpha is set to 0
        float startAlpha = 0f;
        materialPropertyBlock.SetFloat("_Alpha", startAlpha);
        spriteRenderer.SetPropertyBlock(materialPropertyBlock);

        // Gradually decrease alpha to -1 over time
        while (startAlpha > -1f)
        {
            startAlpha -= Time.deltaTime / fadeDuration;
            materialPropertyBlock.SetFloat("_Alpha", startAlpha);
            spriteRenderer.SetPropertyBlock(materialPropertyBlock);
            yield return null;
        }

        // Ensure alpha is exactly -1
        materialPropertyBlock.SetFloat("_Alpha", -1f);
        spriteRenderer.SetPropertyBlock(materialPropertyBlock);

        // Wait for a specified period before calling the DisappearText function
        yield return new WaitForSeconds(5);
        Triggercollider.transform.GetComponent<BoxCollider>().enabled = true;
        // Call the DisappearText function
      //  DisappearText();
    }


    // Function to handle the disappearing effect
    public void DisappearText()
    {
        // Gradually increase DissolveAmount over time
        dissolveTimer += Time.deltaTime;

        if (dissolveTimer <= dissolveDuration)
        {
            float dissolveAmount = Mathf.Lerp(initialDissolveAmount, finalDissolveAmount, dissolveTimer / dissolveDuration);
            materialPropertyBlock.SetFloat("_DissolveAmount", dissolveAmount);
            spriteRenderer.SetPropertyBlock(materialPropertyBlock);

            Debug.Log(dissolveAmount);


            if (dissolveAmount <= finalDissolveAmount - 0.1f)
            {
                spriteRenderer.enabled = false;
            }

        }
    }
}
