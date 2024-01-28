using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAnimation : MonoBehaviour
{
    public Animator elevator;
    public Animator char1;
    public Animator char2;
    public DissolvingController dissolve;

    private bool animationPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        //  elevator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!animationPlayed && other.gameObject.tag == "Player")
        {
            elevator.SetBool("open", true);
            //   char1.SetBool("anim", true);
            char2.SetBool("anim", true);
            dissolvecharacter();
            //   Debug.LogError("elevator anim working");

            animationPlayed = true; // Set the flag to true to indicate animation played
        }
    }

    public void dissolvecharacter()
    {
        dissolve.GetComponent<DissolvingController>().dissolveCharacter();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            elevator.SetBool("open", false);
            //    char1.SetBool("anim", false);
            char2.SetBool("anim", false);
        }
    }
}
