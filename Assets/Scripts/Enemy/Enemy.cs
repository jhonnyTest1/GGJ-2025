using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int life;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject coin;
    private Transform player;
    EnemyPool pool;

    private void Awake()
    {
        AssignVariables();
    }

    private void OnEnable()
    {
        life++;
        AssignVariables();
        coin.gameObject.SetActive(false);
        coin.transform.position = transform.position;
        coin.transform.parent = transform;
    }

    public Transform GetPlayer()
    {
        if (player == null || pool)
            AssignVariables();
        return player;
    }

    private void AssignVariables()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pool = GameObject.FindGameObjectWithTag("EnemyPool").GetComponent<EnemyPool>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPlayerProjectile playerProjectile))
        {
            TakeDamage(playerProjectile.Damage());
        }
    }
    [ContextMenu("Suicide")]
    public void Suicide()
    {
        TakeDamage(life);
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
            Die();
    }

    private void Die()
    {
        coin.transform.parent = null;
        coin.SetActive(true);
        pool.Spawn();
        gameObject.SetActive(false);
    }

    public void Move(float speed, Vector3 direction)
    {
        agent.isStopped = false;
        agent.speed = speed;
        agent.SetDestination(direction);
    }

    public void StopMoving()
    {
        agent.isStopped = true;
        agent.SetDestination(transform.position);
    }
}
