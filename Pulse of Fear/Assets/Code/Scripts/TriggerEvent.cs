using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    [Header("Trigger Settings")]
    public string targetTag = "Player";
    public bool triggerOnce = false;

    [Header("Events")]
    public UnityEvent onEnter;
    public UnityEvent onExit;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            onEnter.Invoke();
            if (triggerOnce)
                hasTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            onExit.Invoke();
            if (triggerOnce)
                hasTriggered = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (triggerOnce && hasTriggered)
            return;

        if (other.CompareTag(targetTag))
        {
            onEnter.Invoke();
            if (triggerOnce)
                hasTriggered = true;
        }
    }
}
