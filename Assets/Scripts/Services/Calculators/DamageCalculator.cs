using System.Collections.Generic;

public class DamageCalculator : Calculator, IDamageCalculator
{
    public DamageCalculator(DamageCalculatorData durationData)
    {
        _defaultDamage = durationData.defaultDamage;
    }

    private List<IntEntry> _defaultDamage;
    public int getDamage(TileType tileType)
    {
        IntEntry entry = _defaultDamage.Find(item => item.tileType == tileType);

        if (entry != null)
        {
            return (_modificatorMap.TryGetValue(tileType, out float modificator) ? entry.value + (int)modificator : entry.value);
        }
        return 0;
    }

    public void StartWork()
    {
    }

    public void EndWork()
    {
    }
    public void increaseModificator(TileType tileType, int costDecrease)
    {
        base.increaseModificator(tileType, costDecrease);
    }

    public void setModificator(TileType tileType, int costDecrease)
    {
        base.setModificator(tileType, costDecrease);
    }

    public void setModificatorForAll(int costDecrease)
    {
        base.setModificatorForAll(costDecrease);
    }
    public void increaseModificatorForAll(int costDecrease)
    {
        base.increaseModificatorForAll(costDecrease);
    }
}
