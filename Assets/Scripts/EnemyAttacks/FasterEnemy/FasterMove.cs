using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class FasterMove : MonoBehaviour
{
    [SerializeField] private float assault;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float distanceToPlayer;

    private Coroutine detectionPlayer;
    private Coroutine startAssault;

    public bool readyToAssault;

    public Enemy enemy;
    private IAttack attack;

    private void OnEnable()
    {
        enemy = GetComponent<Enemy>();
        attack = GetComponent<IAttack>();
        detectionPlayer = StartCoroutine(CheckPlayer());
    }

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        attack = GetComponent<IAttack>();

        if (enemy == null)
        {
            Debug.Log("No hay enemy");
        }

        if (attack == null) 
        {
            Debug.Log("no hay  interfaz");
        }
    }
    void Start()
    {
        detectionPlayer = StartCoroutine(CheckPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChasePlayer()
    {
        enemy.Move(enemySpeed, enemy.GetPlayer().position);
        RotateTowardsPlayer();
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = (enemy.GetPlayer().position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void StopAndAssault()
    {
        enemy.StopMoving();
        RotateTowardsPlayer();

        //attack.Attack(10);
    }

    IEnumerator CheckPlayer()
    {
        ChasePlayer();
        while (true)
        {
            distanceToPlayer = Vector3.Distance(transform.position, enemy.GetPlayer().position);
            if (distanceToPlayer <= assault && readyToAssault == true)
            {
                readyToAssault = false;
                startAssault = StartCoroutine(StartAssault());
                break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator StartAssault()
    {
        Vector3 direction = enemy.GetPlayer().position + transform.position * 15;
        enemy.Move(15, direction);

            yield return new WaitForSeconds(2f);
        detectionPlayer = StartCoroutine(CheckPlayer());
    }
}
