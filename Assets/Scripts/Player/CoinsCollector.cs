using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    [SerializeField] GameObject stats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            stats.GetComponent<IStats>().AddCoins(1);
            other.gameObject.SetActive(false);
        }
    }
}
