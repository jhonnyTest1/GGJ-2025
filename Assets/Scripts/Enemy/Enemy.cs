using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] NavMeshAgent agent;

    public void Move(float speed, Vector3 direction)
    {
        agent.speed = speed;
        agent.SetDestination(direction);
    }

    public void StopMoving()
    {
        agent.isStopped = true;
        agent.SetDestination(transform.position);
    }
}
