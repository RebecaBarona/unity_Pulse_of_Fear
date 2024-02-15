using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStalkerAnimationController : MonoBehaviour
{
    public Animator stalkerAnimator; // Reference to the Animator component
    public string animationParameter = "StalkerStart"; // Name of the animation to play

    public void StartStalkerAnimation()
    {
        stalkerAnimator.SetBool(animationParameter, true); // Play the specified animation
    }
}
