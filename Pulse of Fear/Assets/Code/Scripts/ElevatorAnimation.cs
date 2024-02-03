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

        char2.SetBool("anim", true);

        Debug.Log("Elevator Triggered");

        animationPlayed = true; // Set the flag to true to indicate animation played
        yield return new WaitForSeconds(2);
        character.transform.GetComponent<BoxCollider>().enabled = true;

    }
    public IEnumerator dissolvecharacter()
    {
        dissolve.GetComponent<DissolvingController>().dissolveCharacter();
        yield return new WaitForSeconds(2); 
        elevator.SetBool("open", false);    
        char2.SetBool("anim", false);
        character.transform.GetComponent<BoxCollider>().enabled = false;
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
