using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
  [Header("HUD Components")]
  public TMP_Text currencyText;
  public Image fill;

  public void SetCurrency(int value)
  {
    currencyText.text = "$" + value.ToString();
  }

  public void SetHealth(float current, float max)
  {
    fill.fillAmount = current / max;
  }
}
