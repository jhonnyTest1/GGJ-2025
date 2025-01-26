using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NormalEnemyMove : MonoBehaviour
{
    
    [SerializeField] private float enemySpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float distance;

    private Coroutine detectionPlayer;
    private NavMeshAgent agent;

    public Enemy enemy;
    private IPlayerAttack normalAttack;

    private IAttack attack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        detectionPlayer = StartCoroutine(CheckPlayerPosition());
    }
    void Start()
    {
        attack = GetComponent<IAttack>();
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

    public void DistanceToPlayer() 
    {
        distance = Vector3.Distance(transform.position, enemy.player.position);
        if (distance < 5f)
        {
            attack.Attack(10);
            Debug.Log("Se atacó");
        }
    }


    IEnumerator CheckPlayerPosition()
    {
        while (true)
        {
            ChasePlayer();
            RotateTowardPlayer();
            DistanceToPlayer();
            yield return new WaitForSeconds(0.3f);
        }
    }
    
}
