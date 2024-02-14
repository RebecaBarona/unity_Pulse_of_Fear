using UnityEngine;

public class EyeFollowingPlayer : MonoBehaviour
{
    private GameObject player;
    private Vector3 eyeStartPosition;
    private float size;
    public float detectionRange = 3;
    public float speed = 0.8f;
    public float maxDistance = 10;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        Vector3 size = renderer.bounds.size;
        eyeStartPosition = transform.position;
        this.size = Mathf.Max(size.x, size.y, size.z) * maxDistance;
    }

    Vector3 toLocal(Vector3 vector)
    {
        return transform.InverseTransformPoint(vector);
    }



    void Update()
    {
        Vector3 currentPlayerPosition = toLocal(player.transform.position);
        Vector3 currentEyePosition = toLocal(transform.position);



        Vector3 newEyePositionLocal = new Vector3(Mathf.Clamp(currentPlayerPosition.x, -size, size), currentEyePosition.y,
            currentEyePosition.z);
        Vector3 newEyePositionGlobal = transform.TransformPoint(newEyePositionLocal);
        float distanceEyeToStartPosition = Vector3.Distance(eyeStartPosition, newEyePositionGlobal);
        bool inDetectionRange = Vector3.Distance(player.transform.position, transform.position) < detectionRange;

        if (distanceEyeToStartPosition < size && inDetectionRange)
        {
            transform.position = newEyePositionGlobal;
        }


        if (!inDetectionRange)
        {
            float step = speed * Time.deltaTime; // Calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, eyeStartPosition, step);
        }
    }
}