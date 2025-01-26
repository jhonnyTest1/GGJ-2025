using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour, IStats
{
    [SerializeField] int coins;
    Dictionary<string, float> stats = new();
    Dictionary<string, int> costs = new();
    Dictionary<string, float> increments = new();
    public Dictionary<string, float> capsMax = new();
    public Dictionary<string, float> capsMin = new();

    private void Start()
    {
        stats.Add("damage", 1);
        costs.Add("damage", 4);
        increments.Add("damage", 1.2f);
        capsMax.Add("damage", Mathf.Infinity);

        stats.Add("quantity", 1);
        costs.Add("quantity", 15);
        increments.Add("quantity", 1.2f);
        capsMax.Add("quantity", 5);

        stats.Add("size", 1);
        costs.Add("size", 15);
        increments.Add("size", 1.2f);
        capsMax.Add("size", 2);

        stats.Add("speed", 5);
        costs.Add("speed", 5);
        increments.Add("speed", 1.2f);
        capsMax.Add("speed", 10);

        stats.Add("frecuency", 1);
        costs.Add("frecuency", 30);
        increments.Add("frecuency", 1.2f);
        capsMin.Add("frecuency", 0.1f);

        stats.Add("life", 100);
        costs.Add("life", 5);
        increments.Add("life", 30);
        capsMax.Add("life", 100);

        stats.Add("weapons", 1);
        costs.Add("weapons", 50);
        increments.Add("weapons", 2);
        capsMax.Add("weapons", 2);
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

    public int GetWeapons()
    {
        return (int)stats["weapons"];
    }

    public void AddCoins(int value)
    {
        coins += value;
    }

    public void SetCustomCap(string id, float cap)
    {
        if (capsMax.ContainsKey(id))
            capsMax[id] = cap;
        else if (capsMin.ContainsKey(id))
            capsMin[id] = cap;
    }

    public void SetCustomProperty(string id, float value)
    {
        stats[id] = value;
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
                stats[id] *= increments[id];
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
                stats[id] *= -increments[id];
                Debug.Log(id + " ahora es: " + stats[id]);
            }
        }
        else
        {
            Debug.Log("you broke cuh");
        }
    }
}
