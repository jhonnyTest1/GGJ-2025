using UnityEngine;

public class PlayerLife : MonoBehaviour, IPlayerLife
{
    [SerializeField] GameObject stats;

    public void TakeDamage(int damage)
    {
        if (stats.GetComponent<IStats>().ChangeLife(damage) <= 0)
        {
            gameObject.SetActive(false);
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
