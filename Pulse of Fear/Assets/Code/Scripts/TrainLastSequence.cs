using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationTrigger : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string animationName = "Level02BuildingOpen"; // Name of the animation to play

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the collider is tagged as "Player"
        {
            //  animator = GetComponent<Animator>(); // Get the Animator component attached to this GameObject
            animator.SetBool("wall", true); // Play the specified animation
        }
    }
}

