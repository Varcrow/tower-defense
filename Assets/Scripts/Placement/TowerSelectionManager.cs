using UnityEngine;

public class TowerSelectionManager : MonoBehaviour
{
    public static TowerSelectionManager Instance;

    public GameObject selectedTowerPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectTower(GameObject towerPrefab)
    {
        selectedTowerPrefab = towerPrefab;

        Debug.Log("Tower selected: " + towerPrefab.name);
    }
}
