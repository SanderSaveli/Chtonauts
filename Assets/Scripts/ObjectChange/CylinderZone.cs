using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class CylinderZone : MonoBehaviour
{
    private float radius;
    public int segments = 36;

    private LineRenderer lineRenderer;

    void OnEnable()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void DrawCircle(float radius)
    {
        radius *= 3;
        this.radius = radius;
        float scaledRadius = radius * Mathf.Max(transform.lossyScale.x, transform.lossyScale.z);

        lineRenderer.positionCount = segments + 1;

        float theta = 0f;
        float deltaTheta = 2f * Mathf.PI / segments;

        for (int i = 0; i < segments + 1; i++)
        {
            float x = scaledRadius * Mathf.Cos(theta);
            float z = scaledRadius * Mathf.Sin(theta);

            Vector3 point = transform.position + new Vector3(x, 0f, z);
            lineRenderer.SetPosition(i, point);

            theta += deltaTheta;
        }
    }

    public void hideCircle()
    {
        lineRenderer.positionCount = 0;
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position, radius);
    }
}
