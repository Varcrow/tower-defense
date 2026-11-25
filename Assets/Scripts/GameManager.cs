using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  [Header("Base Game Attributes")]
  public float maxHealth = 50.0f;
  public int startingCurrency = 20;

  [Header("HUD Reference")]
  public HUD hud;

  [Header("Currency Increment")]
  public float interval = 1f;
  public int currencyIncrementAmount = 1;

  private float currentHealth;
  private int currentCurrency;
  private Coroutine currencyRoutine;

  void Start()
  {
    currentHealth = maxHealth;
    currentCurrency = startingCurrency;
    hud.SetCurrency(currentCurrency);
    hud.SetHealth(currentHealth, maxHealth);

    // DEBUG BELOW
    currencyRoutine = StartCoroutine(IncrementCurrency());
  }

  public void UpdateCurrency(int value)
  {
    currentCurrency += value;
    hud.SetCurrency(currentCurrency);
  }

  public void TakeDamage(float value)
  {
    currentHealth = currentHealth - value < 0 ? 0 : currentHealth - value;
    hud.SetHealth(currentHealth, maxHealth);

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

  IEnumerator IncrementCurrency()
  {
    var wait = new WaitForSeconds(interval);
    while (true)
    {
      UpdateCurrency(currencyIncrementAmount);
      yield return wait;
    }
  }
}
