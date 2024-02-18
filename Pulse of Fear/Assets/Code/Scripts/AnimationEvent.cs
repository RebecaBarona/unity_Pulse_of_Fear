using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AnimationEvent : MonoBehaviour
{
    public Animator fade;
    public AudioSource source;

  
    // Start is called before the first frame update

    public void Fade()
    {
        fade.SetBool("fade", true);
        StartCoroutine(LoadMainmenu());
    }

    IEnumerator LoadMainmenu()
    {
        AudioSource[] sources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in sources)
        {
            audioSource.Stop();
        }
        yield return new WaitForSeconds(1);
        source.Play();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }

}
