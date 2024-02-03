using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public float raycastDistance = 10f;
    public Color rayColor = Color.red;

    void Update()
    {
        // Cast a ray from the camera's position forward
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits;

        // Draw the ray in the scene window
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, rayColor);

        // Check if the ray hits something
        hits = Physics.RaycastAll(ray, raycastDistance);

        foreach (RaycastHit hit in hits)
        {
            Collider collider = hit.collider;
            Debug.Log("Raycast hit collider: " + collider.name);

            // Check if the object hit by the ray has the TriggerObject script
            TriggerObject triggerObject = collider.GetComponent<TriggerObject>();
            if (triggerObject != null)
            {
                // Call the function in the TriggerObject script
                triggerObject.OnCameraRaycastHit();
            }
        }
    }
}
