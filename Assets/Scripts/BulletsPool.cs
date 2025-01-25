using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private int poolsize;

    [SerializeField] private List<GameObject> BulletsList;

    private static BulletsPool instance;
    public static BulletsPool Instance {  get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddPoolSize(poolsize);
    }

    private void AddPoolSize(int amount)
    {
        for (int i = 0; i < poolsize; i++)
        {
            GameObject bullet = Instantiate(Bullet);
            bullet.SetActive(false);
            BulletsList.Add(bullet);
            bullet.transform.parent = transform;
        }
    }

    public GameObject RequestBullet()
    {
        for (int i = 0; i < BulletsList.Count; i++ ) 
        {
            if(!BulletsList[i].activeSelf)
            {
                BulletsList[i].SetActive(true);
                return BulletsList[i];
            }
        }
        AddPoolSize(1);
        BulletsList[BulletsList.Count - 1].SetActive(true);
        return BulletsList[BulletsList.Count-1];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
