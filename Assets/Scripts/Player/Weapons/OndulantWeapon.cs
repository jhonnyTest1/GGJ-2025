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
    [SerializeField] float duration = 0;
    Coroutine rollingCoroutine;

    private void Awake()
    {
        Invoke(nameof(StartStats), 0.5f);
    }

    void StartStats()
    {
        IStats istats = stats.GetComponent<IStats>();
        damage = istats.GetDamage();
        istats.SetCustomProperty("speed", istats.GetSpeed() * 40);
        speed = istats.GetSpeed();
        istats.SetCustomCap("speed", istats.GetSpeed() * 3);
        frecuency = istats.GetFrecuency() + 2;
        size = istats.GetSize();
        quantity = istats.GetQuantity();
    }

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
        duration = 0;
        for (int i = 0; i < quantity; i++)
        {
            projectiles[i].SetActive(true);
            projectiles[i].transform.localScale = new Vector3(size, size, size);
        }
        while(duration < 5)
        {
            duration += Time.deltaTime;
            transform.Rotate(Vector3.up * speed * Time.fixedDeltaTime);
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
        for (int i = 0; i < quantity; i++)
        {
            projectiles[i].SetActive(false);
        }
    }
}
