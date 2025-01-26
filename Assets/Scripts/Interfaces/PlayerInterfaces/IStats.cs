public interface IStats
{
    public int GetDamage();

    public float GetSpeed();

    public int GetQuantity();

    public float GetSize();

    public float GetFrecuency();

    public int ChangeLife(int damage);

    public void SetCustomCap(string id, float cap);

    public void SetCustomProperty(string id, float value);
}
