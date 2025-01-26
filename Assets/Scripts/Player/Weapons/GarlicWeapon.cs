using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicWeapon : MonoBehaviour, IPlayerAttack
{
    [SerializeField] int damage;
    [SerializeField] float frecuency;
    [SerializeField] float size;
    [SerializeField] int quantity;
    [SerializeField] List<GameObject> projectiles = new();
    [SerializeField] GameObject stats;
    Coroutine frecuencyBucleCoroutine;
    bool canAttack = true;

    private void Awake()
    {
        Invoke(nameof(StartStats), 0.5f);
    }

    void StartStats()
    {
        IStats istats = stats.GetComponent<IStats>();
        damage = istats.GetDamage();
        frecuency = istats.GetFrecuency();
        size = istats.GetSize();
        quantity = istats.GetQuantity();
    }

    public void SetStats()
    {
        IStats istats = stats.GetComponent<IStats>();
        damage = istats.GetDamage();
        frecuency = istats.GetFrecuency();
        size = istats.GetSize() * 4;
        quantity = istats.GetQuantity();
        if (quantity > projectiles.Count)
            quantity = projectiles.Count;
        for (int i = 0; i < quantity; i++)
        {
            projectiles[i].SetActive(true);
            projectiles[i].transform.localScale = new Vector3(size, size, size);
        }

        frecuencyBucleCoroutine = StartCoroutine(FrecuenceBucle());
    }

    private void OnTriggerStay(Collider other)
    {
        if (canAttack && other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
        }
    }

    IEnumerator FrecuenceBucle()
    {
        float time = 0;
        canAttack = false;
        while (time < frecuency)
        {
            time += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        canAttack = true;
        StopCoroutine(frecuencyBucleCoroutine);
        frecuencyBucleCoroutine = StartCoroutine(FrecuenceBucle());
    }

    public void FinishBehaviour()
    {
        if (frecuencyBucleCoroutine != null)
        StopCoroutine(frecuencyBucleCoroutine);
    }
}
