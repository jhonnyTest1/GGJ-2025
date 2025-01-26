using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour, IStats
{
    [SerializeField] int coins;
    [SerializeField] Dictionary<string, float> stats = new();
    [SerializeField] Dictionary<string, int> costs = new();
    [SerializeField] Dictionary<string, float> increments = new();
    [SerializeField] Dictionary<string, float> capsMax = new();
    [SerializeField] Dictionary<string, float> capsMin = new();

    private void Start()
    {
        stats.Add("damage", 1);
        costs.Add("damage", 100);
        increments.Add("damage", 1);
        capsMax.Add("damage", Mathf.Infinity);

        stats.Add("quantity", 1);
        costs.Add("quantity", 200);
        increments.Add("quantity", 1);
        capsMax.Add("quantity", 5);

        stats.Add("size", 1);
        costs.Add("size", 150);
        increments.Add("size", 1.2f);
        capsMax.Add("size", 3);

        stats.Add("speed", 5);
        costs.Add("speed", 100);
        increments.Add("speed", 1.2f);
        capsMax.Add("speed", 10);

        stats.Add("frecuency", 0.5f);
        costs.Add("frecuency", 300);
        increments.Add("frecuency", 0.1f);
        capsMin.Add("frecuency", 0.1f);

        stats.Add("life", 100);
        costs.Add("life", 50);
        increments.Add("life", 30);
        capsMax.Add("life", 100);

    }

    public int GetDamage()
    {
        return (int)stats["damage"];
    }

    public int GetQuantity()
    {
        return (int)stats["quantity"];
    }

    public float GetSize()
    {
        return stats["size"];
    }

    public float GetSpeed()
    { 
        return stats["speed"];
    }

    public float GetFrecuency()
    {
        return stats["frecuency"];
    }

    public int ChangeLife(int damage)
    {
        stats["life"] -= damage;
        return (int)stats["life"];
    }

    public void BuyPowerUp(string id)
    {
        if (coins >= costs[id])
        {
            if (capsMax.ContainsKey(id))
            {
                if (stats[id] >= capsMax[id])
                {
                    Debug.Log("alcanzaste el limite!");
                    return;
                }
                Debug.Log(id + " antes era: " + stats[id]);
                coins -= costs[id];
                stats[id] += increments[id];
                Debug.Log(id + " ahora es: " + stats[id]);
            }
            else if (capsMin.ContainsKey(id))
            {
                if (stats[id] <= capsMin[id])
                {
                    Debug.Log("alcanzaste el limite!");
                    return;
                }
                Debug.Log(id + " antes era: " + stats[id]);
                coins -= costs[id];
                stats[id] -= increments[id];
                Debug.Log(id + " ahora es: " + stats[id]);
            }
        }
        else
        {
            Debug.Log("you broke cuh");
        }
    }
}
