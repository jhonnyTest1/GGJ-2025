using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] NavMeshAgent agent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPlayerAttack playerAttack))
        {
            TakeDamage(playerAttack.Damage());
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
            Die();
    }

    private void Die()
    {
        //Morir
    }

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
