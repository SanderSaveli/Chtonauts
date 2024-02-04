using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometryChangeTile : InteractiveTile
{
    public float ChangeTimeLeft { get; protected set; }

    [SerializeField] private GameObject _changeTarget;

    private GameObject createdObject;
    private IDurationCalculator _durationCalculator;
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
        StartCoroutine(WaitTimeAndChangeBack(duration));
        ChangeGeometry(false);
        IsChganged = true;
        cell.cellType = CellType.IllusoryWall;
        return true;

    }

    IEnumerator WaitTimeAndChangeBack(float tinme)
    {
        ChangeTimeLeft = tinme;
        while (ChangeTimeLeft > 0)
        {
            ChangeTimeLeft -= Time.deltaTime;
            yield return null;
        }
        ChangeBack();
    }

    protected void ChangeBack()
    {
        ChangeTimeLeft = 0;
        cell.cellType = CellType.Empty;
        IsChganged = false;
        ChangeGeometry(true);
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
}
