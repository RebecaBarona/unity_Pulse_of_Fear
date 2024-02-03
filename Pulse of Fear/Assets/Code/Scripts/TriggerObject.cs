using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    // Reference to the GameObject containing the function to be called
    public GameObject targetObject;

    // Name of the function to be called on the targetObject
    public string functionName;

    // Method to call the function on the targetObject
    public void CallFunctionOnTargetObject()
    {
        if (targetObject == null)
        {
            Debug.LogWarning("Target object not assigned to TriggerObject.");
            return;
        }

        // Check if the targetObject has the specified function
        if (!string.IsNullOrEmpty(functionName) && targetObject.GetComponent<MonoBehaviour>().GetType().GetMethod(functionName) != null)
        {
            targetObject.SendMessage(functionName, SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            Debug.LogWarning("Function '" + functionName + "' not found on target object: " + targetObject.name);
        }
    }

    // The function called when the camera's raycast hits this trigger object
    public void OnCameraRaycastHit()
    {
        // Call the function on the targetObject
        CallFunctionOnTargetObject();
    }
}
