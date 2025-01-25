using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class RangerMove : MonoBehaviour
{
    [SerializeField] private float attackRange = 6f;
    [SerializeField] private float fleeRange = 4f;
    [SerializeField] private float fleeDistance = 10f;
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float fleedSpeed;
    private Coroutine detectionPlayer;

    private Enemy enemy;
    private IAttack rangerAttack;

    public bool isFleeing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = GetComponent<Enemy>();
        rangerAttack = GetComponent<IAttack>();

        detectionPlayer = StartCoroutine(CheckPlayerPosition());

        if (enemy == null)
        {
            Debug.Log("No hay enemy");
        }

        if (rangerAttack == null)
        {
            Debug.Log("No hay script de ataque");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    private void ChasePlayer()
    {
        isFleeing = false;
        enemy.Move(enemySpeed, enemy.player.position);
        RotateTowardsPlayer();
    }

    private void StopAndAttack()
    {
        isFleeing = false;
        enemy.StopMoving();
        RotateTowardsPlayer();  
        rangerAttack.Attack(10); 
    }

    public void FleeFromPlayer()
    {
        Vector3 directionAwayFromPlayer = (transform.position - enemy.player.position).normalized;

        Vector3 fleePosition = transform.position + directionAwayFromPlayer * fleeDistance;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(fleePosition, out hit, 10f, NavMesh.AllAreas))
        {
            enemy.Move(fleedSpeed, hit.position);
            enemy.Move(fleedSpeed, hit.position);
        }
        else
        {
            Debug.LogWarning("No se encontró una posición válida para alejarse.");
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = (enemy.player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    IEnumerator CheckPlayerPosition()
    {
        while (true)
        {

            float distanceToPlayer = Vector3.Distance(transform.position, enemy.player.position);

            if (distanceToPlayer <= fleeRange)
            {
                FleeFromPlayer();
            }
            else if (distanceToPlayer <= attackRange && !isFleeing)
            {
                StopAndAttack();
            }
            else
            {
                ChasePlayer();
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnDisable()
    {
        
    }
}
