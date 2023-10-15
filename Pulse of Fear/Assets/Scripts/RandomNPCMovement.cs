using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomNPCMovement : MonoBehaviour
{
    [SerializeField] Bounds bounds;

    private NavMeshAgent agent;

    Vector3 moveTo;
    private void Start()
    {
        bounds = GameObject.FindWithTag("Ground").GetComponent<Renderer>().bounds;
        agent = GetComponent<NavMeshAgent>();
        SetRandomPointOnNavMesh();
    }

    private void SetRandomPointOnNavMesh()
    {
        float rx = Random.Range(bounds.min.x, bounds.max.x);
        float rz = Random .Range(bounds.min.z, bounds.max.z);
        moveTo = new Vector3(rx, this.transform.position.y,rz);
        
        agent.SetDestination(moveTo);
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            Debug.Log("Destination reached. Finding a new random point.");
            SetRandomPointOnNavMesh();
        }
    }
}
