using UnityEngine;
using Zenject;

public class CircleDamageTile : DurationTile
{
    public float radius;
    public float interval = 1f;

    private float _timer = 0f;
    private IDamageCalculator _damageCalculator;
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
        _timer += Time.deltaTime;

        if (_timer >= interval)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.TryGetComponent(out Reseacher target))
                {
                    target.GetDamage(_damageCalculator.getDamage(TileType));
                }
            }
            _timer = 0f;
        }
    }

    protected override void Deactivation()
    {
        _timer = 0f;
    }

    [Inject] private void Construct(IDamageCalculator damageCalculator)
    {
        _damageCalculator = damageCalculator;
    }
}
