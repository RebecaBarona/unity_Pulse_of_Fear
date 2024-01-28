using System.Collections;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] GameObject NextLevelPrefab;
    [SerializeField] GameObject CurrentLevelPrefab;
  //  [SerializeField] Animator FadeAnim;

    private bool hasLevelChanged = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasLevelChanged && other.gameObject.tag == "Player")
        {
        //    FadeAnim.SetBool("fade", true);
            StartCoroutine(LevelChange());
            hasLevelChanged = true; // Set the flag to true to prevent further level changes
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
    private IEnumerator LevelChange()
    {
        yield return new WaitForSeconds(1);
        NextLevelPrefab.SetActive(true);
        CurrentLevelPrefab.SetActive(false);
      //  FadeAnim.SetBool("fade", false);
    }
}
