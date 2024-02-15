using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrainLastSequence : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string animationName = "TrainLightStart"; // Name of the animation to play

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the collider is tagged as "Player"
        {
          
            animator.SetBool(animationName, true); // Play the specified animation
        }
    }
}

