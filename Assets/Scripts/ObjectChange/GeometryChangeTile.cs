using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class GeometryChangeTile : DurationTile
{

    [SerializeField] private GameObject _changeTarget;

    private GameObject createdObject;
    public List<MeshRenderer> meshes;
    private SurfaceCell cell;
    private NavMeshSurface surface;
    private NavMeshObstacle obstacle;

    private void Start()
    {
        _durationCalculator = ServiceLocator.Get<IDurationCalculator>();
        cell = gameObject.GetComponent<SurfaceCell>();
        surface = GameObject.FindObjectOfType<NavMeshSurface>();
        obstacle = GetComponent<NavMeshObstacle>();
        if(surface == null)
        {
            Debug.LogError("There is no NavMeshSurface on the floor");
        }
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
        return true;
    }

    protected void ChangeGeometry(bool isActive)
    {
        if (isActive)
        {
            if (createdObject != null)
            {
                DestroyImmediate(createdObject);
            }
        }
        else
        {
            if (createdObject == null)
            {
                createdObject = Instantiate(_changeTarget, transform.position, transform.rotation);
            }
        }
        EnableAllMashes(isActive);
        obstacle.enabled = isActive;
        surface.BuildNavMesh();
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
        ChangeGeometry(true);
    }
}
