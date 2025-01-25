using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class RangerMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float attackRange = 6f;
    [SerializeField] private float fleeRange = 4f;
    [SerializeField] private float fleeDistance = 10f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float fleedSpeed;

    private NavMeshAgent agent;
    private RangerAttack RangerAttack;

    public bool isFleeing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        RangerAttack = GetComponent<RangerAttack>();

        if (agent == null)
        {
            Debug.Log("No hay Nav Mesh Agent");
        }

        if (RangerAttack == null)
        {
            Debug.Log("No hay rango de ataque");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float distancetoPlayer = Vector3.Distance(transform.position, player.position);

        if (distancetoPlayer <= fleeRange)
        {
            if (!isFleeing)
            {
                isFleeing = true;
                agent.speed = fleedSpeed;
                FleeFromPlayer();
            }
        }

        if (distancetoPlayer >= attackRange && distancetoPlayer >=fleeDistance) 
        {
            isFleeing =false;
            agent.speed = enemySpeed;
            agent.SetDestination(player.position);
        }
        if (distancetoPlayer <= attackRange && isFleeing == false)
        {
            agent.isStopped = true;
            RangerAttack.Attack(10);
        }
    }

    public void FleeFromPlayer()
    {
        Vector3 directionAwayFromPlayer = (transform.position - player.position).normalized;

        Vector3 fleePosition = transform.position + directionAwayFromPlayer * fleeDistance;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(fleePosition, out hit, 10f, NavMesh.AllAreas))
        {
            agent.isStopped = false;
            agent.SetDestination(hit.position);
        }
        else
        {
            Debug.LogWarning("No se encontró una posición válida para alejarse.");
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
