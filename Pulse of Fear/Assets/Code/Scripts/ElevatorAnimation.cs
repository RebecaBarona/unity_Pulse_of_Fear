using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAnimation : MonoBehaviour
{
    public Animator elevator;

    public Animator char2;
    public DissolvingController dissolve;
    public GameObject character;
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
            StartCoroutine(doorOpening());
        }
    }
    public IEnumerator doorOpening()
    {
        elevator.SetBool("open", true);


        character.transform.GetComponent<BoxCollider>().enabled = true;
        Debug.Log("Elevator Triggered");

        // Set the flag to true to indicate animation played
       yield return null;

    }
    public IEnumerator dissolvecharacter()
    {
        if (animationPlayed == false)
        {
           // char2.SetBool("anim", true);
            animationPlayed = true;

            yield return new WaitForSeconds(2f);
            dissolve.GetComponent<DissolvingController>().dissolveCharacter();
            yield return new WaitForSeconds(3f);
            elevator.SetBool("open", false);

            character.transform.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
        }
    }

    public void DoorCLose()
    {
        StartCoroutine(dissolvecharacter());
        Debug.Log("Door Closing");
    }
}
