using UnityEngine;

public class FloorCell : SurfaceCell
{
    void Start()
    {
        Ray ray = new Ray(transform.position + Vector3.down, Vector3.up * 10);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject clickedObject = hit.collider.gameObject;
            if (clickedObject.TryGetComponent(out Wall wall))
            {
                cellType = CellType.Wall;
                if (gameObject.TryGetComponent(out Collider col))
                {
                    col.enabled = false;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (cellType == CellType.Empty)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawCube(transform.position, new Vector3(0.1f, 0.1f, 0.1f));
        }
    }
}
