using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolvingController : MonoBehaviour
{
    public SkinnedMeshRenderer[] skinnedMeshRenderers;

    [SerializeField] Material[] materials;

    public float dissolveRate = 0.0125f;

    public float refreshRate = 0.025f;

    [SerializeField] GameObject Player;

    bool isDisolving;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
         float distance = Vector3.Distance(transform.position, Player.transform.position);

        if(distance <= 2.5f)
        {
            if(!isDisolving)
            {
                StartCoroutine(DissolveMaterial());
            }
        }
    }

     IEnumerator DissolveMaterial()
    {
        isDisolving = true;
        if(materials.Length > 0)
        {
            float timer = 0;
            while (materials[0].GetFloat("_DissolveAmount") < 1)
            {
                timer += dissolveRate;

                for(int i = 0; i < materials.Length ; i++)
                {
                    materials[i].SetFloat("_DissolveAmount", timer);
                }
                yield return new WaitForSeconds(refreshRate);

              //  isDisolving =false; 
                //this.gameObject.SetActive(false);

            }
        }
    }
}
