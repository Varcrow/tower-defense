using UnityEngine;

public class TowerSelection : MonoBehaviour
{
    public static TowerSelection Instance;

    private TowerRange selectedTowerRange;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectTower(TowerRange towerRange)
    {
        // Hide the previously selected tower's range
        if (selectedTowerRange != null)
        {
            selectedTowerRange.HideRange();
        }

        // Store the newly selected tower
        selectedTowerRange = towerRange;

        // Display the new tower's range
        if (selectedTowerRange != null)
        {
            selectedTowerRange.ShowRange();
        }
    }

    public void DeselectTower()
    {
        if (selectedTowerRange != null)
        {
            selectedTowerRange.HideRange();
            selectedTowerRange = null;
        }
    }
}
