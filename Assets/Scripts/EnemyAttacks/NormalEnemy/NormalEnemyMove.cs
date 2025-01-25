using UnityEngine;
using UnityEngine.AI;

public class NormalEnemyMove : MonoBehaviour
{
    
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float enemySpeed;
    private Coroutine detectionPlayer;
    private NavMeshAgent agent;

    private IPlayerAttack normalAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RotateTowardPlayer()
    {
        
    }
}
