using UnityEngine;

public class OnceDamageTile : DurationTile
{
    public Vector3 direction = Vector3.forward;
    public Vector3 size = Vector3.one;

    private Vector3 boxCenter;

    private void OnEnable()
    {
        boxCenter = transform.TransformDirection(transform.position) + direction;
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
            if (collider.gameObject.TryGetComponent(out DamageTarget target))
            {
                target.GetDamage(ServiceLocator.Get<IDamageCalculator>().getDamage(TileType));
            }
        }
    }

    private void OnDrawGizmos()
    {
        boxCenter = transform.TransformDirection(transform.position) + direction;
        Gizmos.DrawCube(boxCenter, size);
    }
}
