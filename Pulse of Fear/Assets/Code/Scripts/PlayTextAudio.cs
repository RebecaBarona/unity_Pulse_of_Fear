using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTextAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] bool playSound = false;
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
            if (other.gameObject.tag == "Player" && !playSound)
            {
                playSound = true;
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
