using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensityController : MonoBehaviour
{

    public Transform player; // Reference to the player's GameObject
    public Transform targetPosition; // Reference to the target position

    public float maxIntensity = 1.0f; // Maximum intensity
    public float minIntensity = 0.05f; // Minimum intensity
    public float maxDistance = 10.0f; // Maximum distance for full intensity

    private Light directionalLight;

    void Start()
    {
        directionalLight = GetComponent<Light>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null || targetPosition == null)
        {
            Debug.LogWarning("Player or target position is not assigned!");
            return;
        }    
        float distance = Vector3.Distance(player.position, targetPosition.position);     
        float newIntensity = Mathf.Lerp(minIntensity, maxIntensity, distance / maxDistance);   
        newIntensity = Mathf.Clamp(newIntensity, minIntensity, maxIntensity);
        directionalLight.intensity = newIntensity;
    }
}
