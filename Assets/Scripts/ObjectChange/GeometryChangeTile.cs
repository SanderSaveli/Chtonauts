using System.Collections.Generic;
using UnityEngine;

public class GeometryChangeTile : DurationTile
{

    [SerializeField] private GameObject _changeTarget;

    private GameObject createdObject;
    public List<MeshRenderer> meshes;
    private SurfaceCell cell;

    private void Start()
    {
        _durationCalculator = ServiceLocator.Get<IDurationCalculator>();
        cell = gameObject.GetComponent<SurfaceCell>();
    }
    public override bool ActivateTile()
    {
        float duration = _durationCalculator.getDuration(TileType);
        if (IsChganged)
        {
            return false;
        }
        StartCoroutine(WaitTimeAndDeactivation(duration));
        ChangeGeometry(false);
        IsChganged = true;
        cell.State = CellState.IllusoryWall;
        return true;
    }

    protected void ChangeGeometry(bool isActive)
    {
        EnableAllMashes(isActive);
        if (isActive)
        {
            if (createdObject != null)
            {
                Destroy(createdObject);
            }
        }
        else
        {
            if (createdObject == null)
            {
                createdObject = Instantiate(_changeTarget, transform.position, transform.rotation);
            }
        }
    }

    public void EnableAllMashes(bool isAcktive)
    {
        foreach (MeshRenderer mesh in meshes)
        {
            mesh.enabled = isAcktive;
        }
    }

    protected override void Deactivation()
    {
        cell.State = CellState.None;
        ChangeGeometry(true);
    }
}
