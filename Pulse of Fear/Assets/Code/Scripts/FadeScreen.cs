using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    public AnimationCurve fadeCurve;
    private Graphic graphic;

    private Animator animator;
    public int sceneIndex;

    // Start is called before the first frame update

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        graphic = GetComponent<Graphic>();
        graphic.enabled = false;

        // if (fadeOnStart)
        //     FadeIn();
    }

    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
    }

    public void OnFadeComplete()
    {
        SceneTransitionManager.singleton.GoToScene(sceneIndex);
    }

    public void FadeOut()
    {
        Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        graphic.enabled = true;

        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, fadeCurve.Evaluate(timer / fadeDuration));

            graphic.color = newColor;

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        graphic.color = newColor2;

        if (alphaOut == 0)
            graphic.enabled = false;
    }
}
