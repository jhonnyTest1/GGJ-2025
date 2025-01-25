using UnityEngine;
using UnityEngine.AI;

public class NavMeshOnSphere : MonoBehaviour
{
    public Transform worldSphere;
    public float radius;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToCentere = (transform.position - worldSphere.position).normalized;
        Vector3 projectedPosition = worldSphere.position + directionToCentere * radius;

        transform.position = projectedPosition;

        transform.rotation =Quaternion.FromToRotation(Vector3.up, directionToCentere) * transform.rotation;
    }
}
