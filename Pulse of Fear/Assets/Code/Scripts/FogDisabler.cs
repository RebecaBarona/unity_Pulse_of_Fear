

using UnityEngine;
using System.Collections;

public class FogDisabler : MonoBehaviour
{
    public float delayTimeSeconds = 30.0f;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true; 

            RenderSettings.fog = false;
            StartCoroutine(RestartFog());
        }
    }

    private IEnumerator RestartFog() 
    {
        yield return new WaitForSeconds(delayTimeSeconds);
        RenderSettings.fog = true;
    }
}