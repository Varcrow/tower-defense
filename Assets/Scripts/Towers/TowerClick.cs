using UnityEngine;

public class TowerClick : MonoBehaviour
{
    private TowerRange towerRange;

    private void Awake()
    {
        towerRange = GetComponentInChildren<TowerRange>();
    }

    private void OnMouseDown()
    {
        if (towerRange != null)
        {
            TowerSelection.Instance.SelectTower(towerRange);
        }
    }
}
