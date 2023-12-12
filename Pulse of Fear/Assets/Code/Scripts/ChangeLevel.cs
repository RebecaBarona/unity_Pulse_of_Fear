using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] GameObject NextLevelPrefab;
    [SerializeField] GameObject CurrentLevelPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            NextLevelPrefab.SetActive(true);
            CurrentLevelPrefab.SetActive(false);
        }
    }
}
