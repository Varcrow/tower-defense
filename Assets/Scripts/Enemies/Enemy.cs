using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
  [Header("Attributes")]
  public float maxHealth = 3;
  public float damage = 1;
  public float speed = 2f;
  public int currencyValue = 10;

  [Header("Waypoints")]
  public Transform[] wayPoints;

  [Header("Healthbar Image")]
  public Image fill;

  private int currentWayPoint = 0;
  private float currentHealth = 0.0f;

  void Awake() {
    currentHealth = maxHealth;
    fill.fillAmount = currentHealth / maxHealth;
  }

  void Update()
  {
    if (wayPoints == null || wayPoints.Length == 0) return;

    Transform target = wayPoints[currentWayPoint];
    Vector3 dir = (target.position - transform.position).normalized;

    transform.position += dir * speed * Time.deltaTime;

    if (Vector3.Distance(transform.position, target.position) < 0.05f)
    {
      currentWayPoint++;

      if (currentWayPoint >= wayPoints.Length)
      {
        // Most likely will have this get destroyed and deal damage if it hits the base first
        Destroy(gameObject); // TEMP DESTRUCTION TO NOT FILL SCREEN WITH SHITE
      }
    }
  }

  public void TakeDamage(float value) {
    currentHealth -= value;

    // Clamp health to 0
    currentHealth = currentHealth < 0.0f ? 0.0f : currentHealth;

    // Set fill amount for health bar
    fill.fillAmount = currentHealth / maxHealth;

    // Check if this should get cooked
    if (currentHealth <= 0.0f) {
      // Call GameManager.AddCurrency(currencyValue) or something like that
      Destroy(gameObject);
    }
  }
}
