using UnityEngine;

public abstract class InteractiveTile : MonoBehaviour
{
    public bool isAvailable { get; private set; }
    public bool IsChganged
    {
        get => _isChganged;
        protected set
        {
            _isChganged = value;
            OnTileChanged?.Invoke(value);
        }
    }
    public TileType TileType { get => _type; }

    [SerializeField] private TileType _type;
    protected bool _isChganged;

    public delegate void TileChganged(bool isCghangeToTarget);
    public event TileChganged OnTileChanged;

    public abstract bool ActivateTile();
}
