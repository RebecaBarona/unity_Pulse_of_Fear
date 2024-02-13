

using UnityEngine;
using System.Collections;

public class FogDisabler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the collider is tagged as "Player"
        {
            RenderSettings.fog = false;
        }
    }
}