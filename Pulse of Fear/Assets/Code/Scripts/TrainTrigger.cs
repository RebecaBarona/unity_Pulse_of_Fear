using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTrigger : MonoBehaviour
{
    [SerializeField] GameObject Train;
    [SerializeField] Vector3 trainStartPos;
   [SerializeField] Vector3 trainEndPos;
    // Start is called before the first frame update
    void Start()
    {
        trainStartPos = Train.transform.position;
        Train.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Train.SetActive(true);
            Train.GetComponent<Animator>().SetBool("MoveTrain",true);
        }
    }

}
