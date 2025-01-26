using UnityEngine;

public class PlayerProjectile : MonoBehaviour, IPlayerProjectile
{
    [SerializeField] GameObject stats;

    public int Damage()
    {
        return stats.GetComponent<IStats>().GetDamage();
    }
}
