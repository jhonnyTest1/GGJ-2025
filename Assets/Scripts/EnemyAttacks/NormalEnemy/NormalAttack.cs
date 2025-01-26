using System.Collections;
using UnityEngine;

public class NormalAttack : MonoBehaviour, IAttack
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float detectionRadius = 2f;
    [SerializeField] private float detectionInterval = 0.3f;
    [SerializeField] private LayerMask targetLayer;

    private Enemy enemy;
    private float lastAttackTime;

    private void OnEnable()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    public void Attack(int damage)
    {

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, targetLayer);
            enemy.GetPlayer().GetComponent<IPlayerLife>().TakeDamage(10);
            Debug.Log("attque");
            if (colliders.Length > 0)
            {

                foreach (Collider collider in colliders)
                {
                    enemy.GetPlayer().GetComponent<IPlayerLife>().TakeDamage(10);
                    Debug.Log("attque");
                }
            }

            lastAttackTime = Time.time; 
        }
        
    }
}
    