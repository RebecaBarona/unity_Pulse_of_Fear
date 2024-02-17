using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RaycastCheck : MonoBehaviour
{
    public XRBaseInteractor rayInteractor; // Assign your ray interactor in the Inspector

    void Start()
    {
        // Subscribe to the OnHoverEntered event
        rayInteractor.onHoverEntered.AddListener(DebugHoveredObject);
    }

    void DebugHoveredObject(XRBaseInteractable interactable)
    {
        Debug.Log("Hovering over: " + interactable.gameObject.name);
    }
}
