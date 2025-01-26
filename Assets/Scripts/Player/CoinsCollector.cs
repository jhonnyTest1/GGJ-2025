using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    [SerializeField] GameObject stats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {

            other.gameObject.SetActive(false);
        }
    }
}
