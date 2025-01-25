using UnityEngine;

public class RangerAttack : MonoBehaviour, IAttack
{
    public Transform shootPoint;
    public float projectileSpeed = 20f;
    public float attackCooldown;

    private float lastAttackTime;
    public void Attack(int damage)
    {
        //throw new System.NotImplementedException();

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            //GameObject projectile = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            GameObject projectile = BulletsPool.Instance.RequestBullet();
            projectile.transform.position = shootPoint.position;
            projectile.transform.rotation = shootPoint.rotation;    

            // Obtener el Rigidbody del proyectil para aplicar velocidad
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.linearVelocity = shootPoint.forward * projectileSpeed;
            }

            lastAttackTime = Time.time;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
