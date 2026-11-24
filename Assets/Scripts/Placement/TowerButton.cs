using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public GameObject towerPrefab;

    public void SelectTower()
    {
        if (towerPrefab == null)
        {
            Debug.LogWarning("No tower prefab assigned to this button!");
            return;
        }

        TowerSelectionManager.Instance.SelectTower(towerPrefab);
    }
}
