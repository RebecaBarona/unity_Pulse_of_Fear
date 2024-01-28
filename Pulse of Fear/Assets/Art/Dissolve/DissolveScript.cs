using UnityEngine;

public class DissolveScript : MonoBehaviour
{
    public float dissolveDuration = 3f;  // Duration for the dissolve effect
    private SpriteRenderer spriteRenderer;
    private MaterialPropertyBlock materialPropertyBlock;
    private float dissolveTimer = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("DissolveScript requires a SpriteRenderer component!");
            enabled = false;  // Disable the script if the required components are not present
        }

        materialPropertyBlock = new MaterialPropertyBlock();
        spriteRenderer.GetPropertyBlock(materialPropertyBlock);
    }

    void Update()
    {
        



    }

    public void DisappearText()
    {
        // Gradually increase DissolveAmount over time
        dissolveTimer += Time.deltaTime;

        if (dissolveTimer <= dissolveDuration)
        {
            float dissolveAmount = Mathf.Lerp(0f, 1.3f, dissolveTimer / dissolveDuration);
            materialPropertyBlock.SetFloat("_DissolveAmount", dissolveAmount);
            spriteRenderer.SetPropertyBlock(materialPropertyBlock);
        }
    }
}
