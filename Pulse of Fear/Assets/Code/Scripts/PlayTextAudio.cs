using UnityEngine;

public class PlayTextAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    
    public bool hasPlayed = false;
 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        Debug.Log("started" + this.gameObject);
        Debug.Log("PlayTextAudio started on: " + gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (audioSource != null && !hasPlayed)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                audioSource.Play();
                hasPlayed = true;

            
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
