using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NormalEnemyMove : MonoBehaviour
{
    
    [SerializeField] private float enemySpeed;
    [SerializeField] private float turnSpeed;

    private Coroutine detectionPlayer;
    private NavMeshAgent agent;

    private Enemy enemy;
    private IPlayerAttack normalAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = GetComponent<Enemy>();
        normalAttack = GetComponent<IPlayerAttack>();   
        detectionPlayer = StartCoroutine(CheckPlayerPosition());
    }

    private void RotateTowardPlayer()
    {
        Vector3 direction = (enemy.GetPlayer().position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void ChasePlayer()
    {
        enemy.Move(enemySpeed, enemy.GetPlayer().position);
    }

    IEnumerator CheckPlayerPosition()
    {
        while (true)
        {
            ChasePlayer();
            RotateTowardPlayer();
            yield return new WaitForSeconds(0.3f);
        }
    }
    
}
