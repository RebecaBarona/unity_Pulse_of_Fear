using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollowingPlayer : MonoBehaviour
{
    private GameObject player;
    public bool moveAlongX = false;
    public bool moveAlongY = false;
    public bool moveAlongZ = false;
    public float detectionRadius = 5;
    public float speed = 1f;

    private Vector3 startPosition;
    private Vector3 playerPreviousPosition;
    private Vector3 size;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPreviousPosition = player.transform.position;
        startPosition = transform.position;
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        size = renderer.bounds.size;
    }



    void Update()
    {
        Vector3 playerDelta = player.transform.position - playerPreviousPosition;
        move(playerDelta);
        playerPreviousPosition = player.transform.position;
    }


    void move(Vector3 playerDelta)
    {
        playerDelta *= speed;
        Vector3 newPos = transform.position + playerDelta;
        float distanceFromStartingPosition = Vector3.Distance(newPos, startPosition);
        float distancePlayerEye = Vector3.Distance(player.transform.position, transform.position);
        float maxSize = Mathf.Max(size.x, size.y, size.z);
        if (distanceFromStartingPosition > maxSize)
        {
            return;
        }
        if (distancePlayerEye > detectionRadius)
        {
            return;
        }
        float maxX = startPosition.x + maxSize;
        float minX = startPosition.x - maxSize;

        float maxY = startPosition.y + maxSize;
        float minY = startPosition.y - maxSize;

        float maxZ = startPosition.z + maxSize;
        float minZ = startPosition.z - maxSize;

        if (moveAlongX && player.transform.position.x > minX && player.transform.position.x < maxX)
        {
            transform.Translate(new Vector3(playerDelta.x, 0, 0));
        }

        if (moveAlongY && player.transform.position.y > minY && player.transform.position.y < maxY)
        {
            transform.Translate(new Vector3(0, playerDelta.y, 0));
        }

        if (moveAlongZ && player.transform.position.z > minZ && player.transform.position.z < maxZ)
        {
            transform.Translate(new Vector3(0, 0, playerDelta.z));
        }

    }
}