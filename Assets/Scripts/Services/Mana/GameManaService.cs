public class GameManaService : IManaService
{
    IManaPool pool;

    public GameManaService(ManaServiceData data, IManaPool manaPool)
    {
        pool = manaPool;
        manaPool.CurrentMana = data.startMana;
        manaPool.PoolSize = data.maxMana;
        manaPool.ManaPerSecondIncrease = data.manaIncreasePerSecond;
    }

    public float currentMana => pool.CurrentMana;

    public float currentManaIncrease => pool.ManaPerSecondIncrease;

    public int maxMana => pool.PoolSize;

    public void EndWork()
    {
    }

    public void StartWork()
    {
    }

    public bool TrySpendMana(int count)
    {
        return pool.TrySpendMana(count);
    }
}
