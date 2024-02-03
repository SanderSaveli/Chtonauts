using System.Collections.Generic;
using UnityEngine;

public abstract class Calculator : MonoBehaviour
{
    protected Dictionary<TileType, float> _modificatorMap = new Dictionary<TileType, float>();

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
}
