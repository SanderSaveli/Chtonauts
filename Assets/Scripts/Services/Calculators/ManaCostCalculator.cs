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
            return (int)(_modificatorMap.TryGetValue(tileType, out float modificator) ? entry.changeCost + modificator : entry.changeCost);
        }
        return 0;
    }

    public void StartWork()
    {   }

    public void EndWork()
    {   }
}
