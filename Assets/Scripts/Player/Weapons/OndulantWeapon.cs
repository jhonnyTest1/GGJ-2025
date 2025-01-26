using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndulantWeapon : MonoBehaviour, IPlayerAttack
{
    [SerializeField] int damage;
    [SerializeField] float speed;
    [SerializeField] float frecuency;
    [SerializeField] float size;
    [SerializeField] int quantity;
    [SerializeField] List<GameObject> projectiles = new();
    [SerializeField] GameObject stats;
    float duration = 0;
    Coroutine rollingCoroutine;

    [ContextMenu("Set Stats")]
    public void SetStats()
    {
        IStats istats = stats.GetComponent<IStats>();
        damage = istats.GetDamage();
        speed = istats.GetSpeed();
        frecuency = istats.GetFrecuency();
        size = istats.GetSize();
        quantity = istats.GetQuantity();

        rollingCoroutine = StartCoroutine(Rolling());
    }

    IEnumerator Rolling()
    {
        for (int i = 0; i < quantity; i++)
        {
            projectiles[i].SetActive(true);
        }
        while(duration < 5)
        {
            duration = Time.deltaTime;
            transform.Rotate(Vector3.up * speed);
            yield return new WaitForFixedUpdate();
        }
        for (int i = 0; i < quantity; i++)
        {
            projectiles[i].SetActive(false);
        }
        yield return new WaitForSeconds(frecuency);
        StopCoroutine(rollingCoroutine);
        rollingCoroutine = StartCoroutine(Rolling());
    }

    public void FinishBehaviour()
    {
        StopCoroutine(rollingCoroutine);
    }

    public int Damage()
    {
        throw new System.NotImplementedException();
    }
}
