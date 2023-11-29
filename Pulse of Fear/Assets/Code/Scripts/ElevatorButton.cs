using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ElevatorButton : MonoBehaviour
{

    [SerializeField] GameObject Platform;
    Vector3 platformInitialPos;
    [SerializeField] Vector3 platformMoveDistance;

    public float platformMoveTime;
    bool platformIsMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        platformInitialPos = Platform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void MovePlatform()
    {
        if(!platformIsMoving)
        {
            StartCoroutine(MovingPlatform()); 
        }
    }

    public IEnumerator MovingPlatform()
    {
        platformIsMoving = true;

        platformIsMoving = true;
        float elapsedTime = 0f;
        Vector3 initialPlatformPos = Platform.transform.position;
        Vector3 targetPlatformPos = platformInitialPos + platformMoveDistance;

        while (elapsedTime < platformMoveTime)
        {
           
            Platform.transform.position = Vector3.Lerp(initialPlatformPos, targetPlatformPos, elapsedTime / platformMoveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Platform.transform.position = targetPlatformPos;
        platformIsMoving = false;
    }
}
