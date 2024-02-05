using UnityEngine;

public class CircleDamageTileView : GeometryChangeTileView
{
    [SerializeField] private CylinderZone cylinderZone;
    private CircleDamageTile damageTile;

    private void Start()
    {
        damageTile = GetComponentInParent<CircleDamageTile>();
    }
    protected override void TileActive()
    {
        base.TileActive();
        cylinderZone.DrawCircle(damageTile.radius);
        cylinderZone.enabled = true;
    }
    protected override void TileDeactiveted()
    {
        base.TileDeactiveted();
        cylinderZone.hideCircle();
    }
}
