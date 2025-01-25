using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener el Rigidbody del proyectil para aplicar velocidad
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.linearVelocity = transform.forward * projectileSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.TryGetComponent(out IPlayerAttack playerAttack))
            gameObject.SetActive(false);
    }
}
