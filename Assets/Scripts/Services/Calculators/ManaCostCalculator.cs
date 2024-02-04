using System.Collections.Generic;

public class ManaCostCalculator : Calculator, IManaCostCalculator
{
    public ManaCostCalculator(ManaCostData manaCostData)
    { 
        defaultCost = manaCostData.defaultCost;
    }

    private List<CostEntry> defaultCost;
    public int getCost(TileType tileType)
    {
        CostEntry entry = defaultCost.Find(item => item.tileType == tileType);

        if (entry != null)
        {
            return (int)(_modificatorMap.TryGetValue(tileType, out float modificator) ? 
                entry.changeCost + modificator + _modificatorForAll : 
                entry.changeCost + _modificatorForAll);
        }
        return 0;
    }

    public void StartWork()
    {   }

    public void EndWork()
    {   }

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
