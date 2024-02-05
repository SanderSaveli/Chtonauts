using System.Collections.Generic;
using UnityEngine;

public class DurationCalculator : Calculator, IDurationCalculator
{
    public DurationCalculator(DurationData durationData)
    {
        _defaultDurations = durationData.defaultDurations;
    }

    private List<FloatEntry> _defaultDurations;
    public float getDuration(TileType tileType)
    {
        FloatEntry entry = _defaultDurations.Find(item => item.tileType == tileType);

        if (entry != null)
        {
            return (_modificatorMap.TryGetValue(tileType, out float modificator) ? entry.value + modificator : entry.value);
        }
        return 0;
    }

    public void StartWork()
    {   }

    public void EndWork()
    {   }
}
