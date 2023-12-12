using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTextAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (audioSource != null)
        {
            if(other.gameObject.tag == "Player")
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
