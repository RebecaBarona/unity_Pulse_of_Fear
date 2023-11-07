using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddScene : MonoBehaviour
{
    public GameObject Player;
    public int LevelIndex;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            DontDestroyOnLoad(Player);
            SceneManager.LoadScene(LevelIndex, LoadSceneMode.Additive);
            this.gameObject.SetActive(false);
        }
    }
}
