using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public sealed class PerseptionZone : MonoBehaviour
{
    [field: SerializeField] public UnityEvent<FloorCell> OnFloorCellEnter { get; private set; }
    [field: SerializeField] public UnityEvent<FloorCell> OnFloorCellExit { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FloorCell floorCell))
        {
            OnFloorCellEnter?.Invoke(floorCell);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out FloorCell floorCell))
        {
            OnFloorCellExit?.Invoke(floorCell);
        }
    }
}
