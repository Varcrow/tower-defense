using UnityEngine;

public class TowerDeselect : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(
                mousePosition,
                Vector2.zero
            );

            if (hit.collider == null)
            {
                TowerSelection.Instance.DeselectTower();
            }
        }
    }
}
