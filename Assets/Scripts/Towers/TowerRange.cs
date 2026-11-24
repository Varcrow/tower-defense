using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TowerRange : MonoBehaviour
{
    public int segments = 100;

    private LineRenderer lineRenderer;
    private TowerAttack towerAttack;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        towerAttack = GetComponentInParent<TowerAttack>();

        if (towerAttack == null)
        {
            Debug.LogError("TowerAttack not found on parent tower!");
            return;
        }

        DrawRangeCircle();

        // Hide the range circle when the tower spawns
        lineRenderer.enabled = false;
    }

    private void DrawRangeCircle()
    {
        float range = towerAttack.attackRange;

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

    public void ShowRange()
    {
        lineRenderer.enabled = true;
    }

    public void HideRange()
    {
        lineRenderer.enabled = false;
    }
}