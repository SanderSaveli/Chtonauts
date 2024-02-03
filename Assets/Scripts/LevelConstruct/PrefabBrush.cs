using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabBrush", menuName = "Brushes/Prefab Brush")]
[CustomGridBrush(false, true, false, "Prefab Brush")]
public class PrefabBrush : GameObjectBrush
{
    public override void Erase(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
    {
        if(brushTarget.layer == 31) 
        {
            return;
        }
        Transform erazed = GetObjectInCell(gridLayout, brushTarget.transform, new Vector3Int(position.x, position.y, 0));
        if (erazed != null)
        {
            Undo.DestroyObjectImmediate(erazed);
        }
    }

    private static Transform GetObjectInCell(GridLayout grid, Transform parent, Vector3Int position) 
    {
        int childCount = parent.childCount;
        Vector3 min = grid.LocalToWorld(grid.CellToLocalInterpolated(position));
        Vector3 max = grid.LocalToWorld(grid.CellToLocalInterpolated(position + Vector3Int.one));
        Bounds bounds = new Bounds((min+ max) * 0.5f, max - min);

        for (int i = 0; i < childCount; i++) 
        { 
            Transform child = parent.GetChild(i);
            if (bounds.Contains(child.position))
            {
                return child;
            }
        }
        return null;
    }
}
