using System.Collections.Generic;
using UnityEngine;

public abstract class Calculator
{
    protected Dictionary<TileType, float> _modificatorMap = new Dictionary<TileType, float>();
    protected float _modificatorForAll;

    public void increaseModificator(TileType tileType, float duration)
    {
        if (_modificatorMap.ContainsKey(tileType))
        {
            _modificatorMap[tileType] += duration;
        }
        else
        {
            _modificatorMap.Add(tileType, duration);
        }
    }

    public void setModificator(TileType tileType, float duration)
    {
        if (_modificatorMap.ContainsKey(tileType))
        {
            _modificatorMap[tileType] = duration;
        }
        else
        {
            _modificatorMap.Add(tileType, duration);
        }
    }

    public void setModificatorForAll(float costDecrease)
    {
        _modificatorForAll = costDecrease;
    }
    public void increaseModificatorForAll(float costDecrease)
    {
        _modificatorForAll += costDecrease;
    }
}
