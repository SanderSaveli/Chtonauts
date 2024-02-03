using System.Collections.Generic;

public class ManaCostCalculator : Calculator
{
    [System.Serializable]
    public class CostEntry
    {
        public TileType tileType;
        public float changeCost;
    }

    public List<CostEntry> defaultCost;
    public int getCost(TileType tileType)
    {
        CostEntry entry = defaultCost.Find(item => item.tileType == tileType);

        if (entry != null)
        {
            return (int)(_modificatorMap.TryGetValue(tileType, out float modificator) ? entry.changeCost + modificator : entry.changeCost);
        }
        return 0;
    }
}
