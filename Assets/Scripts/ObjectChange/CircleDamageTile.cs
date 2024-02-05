using UnityEngine;

public class CircleDamageTile : DurationTile
{
    public float radius;
    private float timer = 0f;
    public float interval = 1f;
    public override bool ActivateTile()
    {
        float duration = _durationCalculator.getDuration(TileType);
        if (IsChganged)
        {
            return false;
        }
        StartCoroutine(WaitTimeAndDeactivation(duration));
        IsChganged = true;
        return true;
    }

    protected override void ActivationUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.TryGetComponent(out Reseacher target))
                {
                    target.GetDamage(ServiceLocator.Get<IDamageCalculator>().getDamage(TileType));
                }
            }
            timer = 0f;
        }
    }

    protected override void Deactivation()
    {
        timer = 0f;
    }
}
