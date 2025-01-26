using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] List<GameObject> pool = new();
    [SerializeField] List<Transform> spawnPoints = new();
    public int enemyCount = 1;
    public int enemiesLife = 1;

    public void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        if (pool[0].activeSelf)
        {
            pool.Add(Instantiate(pool[Random.Range(0, pool.Count)], spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity));
        }
        else
        {
            pool[0].transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)].position;
            pool[0].SetActive(true);
            RotateOrders();
        }
    }

    void RotateOrders()
    {
        GameObject actual = null;
        GameObject save = null;

        for (int i = 0; i < pool.Count; i++)
        {
            if (i == 0)
            {
                actual = pool[i];
                save = pool[i + 1];
                pool[i + 1] = actual;
            }
            else if (i < pool.Count - 1)
            {
                actual = save;
                save = pool[i + 1];
                pool[i + 1] = actual;
            }
            else
            {
                pool[0] = save;
            }
        }
    }
}
