using System.Collections.Generic;
using UnityEngine;

public class AmbientController : MonoBehaviour
{
    public List<Transform> ambientPoints;   // List of points forming a random shape path
    public AudioSource ambientAudio;         // Audio source on the GameObject
    public Transform player;                 // Player's transform
    public float minVolume = 0.2f;           // Minimum volume when closest to the first point
    public float maxVolume = 0.8f;           // Maximum volume when reaching the last point

    void Update()
    {
        // Check if necessary components are assigned
        if (ambientPoints.Count == 0 || ambientAudio == null || player == null)
        {
            Debug.LogWarning("Make sure to assign ambient points, the ambient audio source, and the player's transform in the inspector.");
            return;
        }

        // Calculate the total distance along the entire path
        float totalDistance = CalculateTotalDistance();

        // Calculate the distance traveled along the path from the first point to the player
        float distanceToPlayer = CalculateDistanceToPlayer();

        // Normalize the distance between 0 and 1
        float normalizedDistance = Mathf.Clamp01(distanceToPlayer / totalDistance);

        // Calculate the volume based on the normalized distance
        float volume = Mathf.Lerp(minVolume, maxVolume, normalizedDistance);

        // Set the volume of the ambient audio source on this GameObject
        ambientAudio.volume = volume;

        // Debug statements
        Debug.Log("Volume: " + volume);
        Debug.Log("Length of the entire path: " + totalDistance);
        Debug.Log("Player progression along the path: " + distanceToPlayer);
    }

    float CalculateTotalDistance()
    {
        float totalDistance = 0f;

        // Calculate the total distance along the entire path
        for (int i = 0; i < ambientPoints.Count - 1; i++)
        {
            totalDistance += Vector3.Distance(ambientPoints[i].position, ambientPoints[i + 1].position);
        }

        return totalDistance;
    }

    float CalculateDistanceToPlayer()
    {
        float distanceToPlayer = 0f;

        // Calculate the distance traveled along the path from the first point to the player
        for (int i = 0; i < ambientPoints.Count - 1; i++)
        {
            float distance = Vector3.Distance(player.position, ambientPoints[i].position);

            // If the player has reached or passed the current point, break the loop
            if (distanceToPlayer + distance >= Vector3.Distance(player.position, ambientPoints[i + 1].position))
            {
                break;
            }

            distanceToPlayer += distance;
        }

        return distanceToPlayer;
    }
}
