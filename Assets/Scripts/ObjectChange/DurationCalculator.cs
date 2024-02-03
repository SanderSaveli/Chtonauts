using System.Collections.Generic;
using UnityEngine;

public class DurationCalculator : Calculator
{
    [System.Serializable]
    public class TileDurationEntry
    {
        public TileType tileType;
        public int changeDuration;
    }

    public List<TileDurationEntry> defaultDurations;
    public float getDuration(TileType tileType)
    {
        TileDurationEntry entry = defaultDurations.Find(item => item.tileType == tileType);

        if (entry != null)
        {
            return (_modificatorMap.TryGetValue(tileType, out float modificator) ? entry.changeDuration + modificator : entry.changeDuration);
        }
        return 0;
    }
}
