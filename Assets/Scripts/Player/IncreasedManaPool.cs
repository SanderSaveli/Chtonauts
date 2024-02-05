using UnityEngine;

public class IncreasedManaPool : MonoBehaviour, IManaPool
{
    public int AvailableMana => Mathf.FloorToInt(CurrentMana);

    public int PoolSize { get; set; }
    public float ManaPerSecondIncrease { get; set; }

    public float CurrentMana { get; set; }

    public bool TrySpendMana(int count)
    {
        if (AvailableMana < count)
        {
            return false;
        }
        else
        {
            CurrentMana -= count;
            return true;
        }
    }

    private void Update()
    {
        float addedMana = CurrentMana + ManaPerSecondIncrease * Time.deltaTime;
        CurrentMana = Mathf.Clamp(addedMana, 0, PoolSize);
    }
}
