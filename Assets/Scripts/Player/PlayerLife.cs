using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour, IPlayerLife
{
    [SerializeField] GameObject stats;
    [SerializeField] GameObject menu;

    public void TakeDamage(int damage)
    {
        if (stats.GetComponent<IStats>().ChangeLife(damage) <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
