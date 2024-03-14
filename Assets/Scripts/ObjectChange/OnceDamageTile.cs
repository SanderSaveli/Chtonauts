using UnityEngine;
using Zenject;

public class OnceDamageTile : DurationTile
{
    public Vector3 direction = Vector3.forward;
    public Vector3 size = Vector3.one;

    private Vector3 boxCenter;
    private IDamageCalculator _damageCalculator;

    private void OnEnable()
    {
        boxCenter = transform.position + transform.forward;
    }

    [Inject] private void Consruct(IDamageCalculator damageCalculator)
    {
        _damageCalculator = damageCalculator;
    }

    public override bool ActivateTile()
    {
        float duration = _durationCalculator.getDuration(TileType);
        if (IsChganged)
        {
            return false;
        }
        MakeHit();
        StartCoroutine(WaitTimeAndDeactivation(duration));
        IsChganged = true;
        return true;
    }

    protected override void Deactivation()
    { }

    protected void MakeHit()
    {
        Collider[] colliders = Physics.OverlapBox(boxCenter, size / 2);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out Reseacher target))
            {
                target.GetDamage(_damageCalculator.getDamage(TileType));
            }
        }
    }

    private void OnDrawGizmos()
    {
        boxCenter = transform.position + transform.forward;
        Gizmos.DrawCube(boxCenter, size);
    }
}
