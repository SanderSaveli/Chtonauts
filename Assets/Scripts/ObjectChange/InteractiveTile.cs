using UnityEngine;

public abstract class InteractiveTile : MonoBehaviour
{
    public bool isAvailable { get => !_isChganged; private set { _isChganged = !value; } }
    public bool IsChganged
    {
        get => _isChganged;
        protected set
        {
            _isChganged = value;
            if (value)
            {
                OnTileActive?.Invoke();
            }
            else
            {
                OnTileDeactiveted?.Invoke();
            }
        }
    }
    public TileType TileType { get => _type; }

    [SerializeField] private TileType _type;
    protected bool _isChganged;

    public delegate void TileChganged();
    public event TileChganged OnTileActive;
    public event TileChganged OnTileDeactiveted;

    public abstract bool ActivateTile();
}
