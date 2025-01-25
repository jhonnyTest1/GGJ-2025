using UnityEngine;

public class RangerAttack : MonoBehaviour, IAttack
{
    public Transform shootPoint;
    public float projectileSpeed = 20f;
    public float attackCooldown;
    private Enemy enemy;

    private float lastAttackTime;
    public void Attack(int damage)
    {
        //throw new System.NotImplementedException();

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            GameObject projectile = BulletsPool.Instance.RequestBullet();
            projectile.transform.position = shootPoint.position;
            Vector3 direction = transform.position - enemy.player.position;
            projectile.transform.forward = -direction;    

            lastAttackTime = Time.time;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
