using System.Collections;
using UnityEngine;

public class NormalAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float detectionRadius = 2f;
    [SerializeField] private float detectionInterval = 0.3f;
    [SerializeField] private LayerMask targetLayer;
    private Coroutine CheckPlayer;

    private Enemy enemy;
    private float lastAttackTime;

    private void OnEnable()
    {
        CheckPlayer = StartCoroutine(CheckforPlayer());
    }

    private void Start()
    {
        CheckPlayer = StartCoroutine(CheckforPlayer());
    }

    IEnumerator CheckforPlayer()
    {
        while (true)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, targetLayer);
            if (colliders.Length > 0)
            {
                foreach (Collider collider in colliders)
                {
                    Debug.Log("Choco al jugador");
                }
            }
            yield return new WaitForSeconds(0.3f);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
    