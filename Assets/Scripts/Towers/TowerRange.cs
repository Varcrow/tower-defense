using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TowerRange : MonoBehaviour
{
    public float range = 3f;
    public int segments = 100;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        DrawRangeCircle();
    }

    void DrawRangeCircle()
    {
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;
        lineRenderer.positionCount = segments;
        lineRenderer.startWidth = 0.03f;
        lineRenderer.endWidth = 0.03f;

        for (int i = 0; i < segments; i++)
        {
            float angle = i * Mathf.PI * 2f / segments;

            float x = Mathf.Cos(angle) * range;
            float y = Mathf.Sin(angle) * range;

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}