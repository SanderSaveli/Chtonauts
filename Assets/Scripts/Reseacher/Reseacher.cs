using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;

public sealed class Reseacher : MonoBehaviour
{
    [field: SerializeField] public int IllusionWallMindDamage { get; private set; }
    [field: SerializeField] public int MaxMind { get; private set; }
    [field: SerializeField] public int MaxHealth { get; private set; }

    [field: SerializeField] public UnityEvent<int> OnMindChanged { get; private set; }
    [field: SerializeField] public UnityEvent<int> OnHealthChanged { get; private set; }
    [field: SerializeField] public UnityEvent OnIllusoryWallDiscovered { get; private set; }

    public int Mind { get; private set; }
    public int Health { get; private set; }

    private readonly Dictionary<FloorCell, CellState> _memory = new();

    private void Awake()
    {
        Mind = MaxMind;
        Health = MaxHealth;
    }

    public void ChangeMind(int newValue)
    {
        Mind = newValue;
        OnMindChanged?.Invoke(Mind);
    }

    public void ChangeHealth(int newValue)
    {
        Health = newValue;
        OnHealthChanged?.Invoke(Health);
    }

    public void GetDamage(int value)
    {
        Mind -= value;
        Debug.Log(Mind);
        OnMindChanged?.Invoke(Mind);
    }

    public void OnCellDiscovered(FloorCell floorCell)
    {
        if (_memory.ContainsKey(floorCell))
        {
            CellState rememberedState = _memory[floorCell];
            if ((rememberedState == CellState.None) && (floorCell.State == CellState.IllusoryWall))
            {
                ChangeMind(IllusionWallMindDamage);
                OnIllusoryWallDiscovered?.Invoke();
            }
        }
        else
        {
            _memory.Add(floorCell, floorCell.State);
        }
    }
}
