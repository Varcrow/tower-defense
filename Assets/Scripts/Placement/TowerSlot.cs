using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    private bool isOccupied = false;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (!isOccupied)
        {
            PlaceTower();
        }
    }

    private void PlaceTower()
    {
        GameObject selectedTower =
            TowerSelectionManager.Instance.selectedTowerPrefab;

        if (selectedTower == null)
        {
            Debug.Log("No tower selected!");
            return;
        }

        Instantiate(selectedTower, transform.position, Quaternion.identity);

        isOccupied = true;

        // Hide the hexagon after placing the tower
        spriteRenderer.enabled = false;

        Debug.Log("Tower placed successfully!");
    }
}
