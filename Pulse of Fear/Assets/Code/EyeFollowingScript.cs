using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollowingPlayer : MonoBehaviour
{
    private GameObject player;
    public bool moveAlongX = false;
    public bool moveAlongY = false;
    public bool moveAlongZ = false;

    private Vector3 startPosition;
    private Vector3 size;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = transform.position;
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        size = renderer.bounds.size;
    }



    void Update()
    {
        Vector3 localStartPos = transform.InverseTransformPoint(startPosition);
        Vector3 delta = transform.InverseTransformDirection(player.transform.position - transform.position);
        float maxSize = Mathf.Max(size.x, size.y, size.z);
        Vector3 translationVector = Vector3.zero;
        if (moveAlongX)
        {
            translationVector = new Vector3(delta.x, 0, 0);

        }
        else if (moveAlongZ)
        {
            translationVector = new Vector3(0, 0, delta.z);

        }
        else if (moveAlongY)
        {
            translationVector = new Vector3(0, delta.y, 0);
        }
        Vector3 newPosLocal = transform.InverseTransformPoint(transform.position) + translationVector;
        float distanceLocal = Vector3.Distance(newPosLocal, localStartPos);
        if (distanceLocal < maxSize)
        {
            transform.Translate(translationVector);
        }

    }
}