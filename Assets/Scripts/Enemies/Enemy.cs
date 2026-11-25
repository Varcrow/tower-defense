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
        GameManager gm = FindFirstObjectByType<GameManager>(); // THIS RIGHT HERE SUCKS AND SEARCHES THE ENTIRE SCENE OVER AND OVER; FIX WHEN NOT LAZY
        gm.TakeDamage(damage);
        Destroy(gameObject); // TEMP DESTRUCTION TO NOT FILL SCREEN WITH SHITE; PROBABLY GONNA BE PERMANANT BECAUSE WHY NOT
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
      GameManager gm = FindFirstObjectByType<GameManager>(); // THIS STILL SUCKS WHY AM I PUTTING IT HERE AGAIN???
      gm.UpdateCurrency(currencyValue);
      Destroy(gameObject);
    }
  }
}
