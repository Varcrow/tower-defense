using UnityEngine;

public class GameManager : MonoBehaviour
{
  [Header("Base Game Attributes")]
  public float maxHealth = 50.0f;
  public int startingCurrency = 20;

  private float currentHealth;
  public int currentCurrency;

  void Start()
  {

  }

  void Update()
  {

  }

  void UpdateCurrency(int value) {
    currentCurrency += value;
    // TODO: UPDATE CURRENCY UI
  }

  public void TakeDamage(float value)
  {
    currentHealth = currentHealth - value < 0 ? 0 : currentHealth - value;

    // TODO: UPDATE HEALTH UI HERE

    if (currentHealth <= 0)
    {
      // TODO: GAME OVER LOGIC HERE
      Debug.Log("Game is over");
    }
  }

  public bool TrySpend(int cost)
  {
    if ((currentCurrency - cost) < 0)
    {
      return false;
    }

    UpdateCurrency(-cost);
    return true;
  }
}
