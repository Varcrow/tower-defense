using UnityEngine;

public class Enemy : MonoBehaviour
{
  public int health = 3;
  public int damage = 1;
  public int currencyValue = 10;
  public float speed = 2f;
  public Transform[] wayPoints;

  private int currentWayPoint = 0;

  void Update()
  {
    if (wayPoints == null || wayPoints.Length == 0) return;

    Transform target = wayPoints[currentWayPoint];
    Vector3 dir = (target.position - transform.position).normalized;

    transform.position += dir * speed * Time.deltaTime;

    if (Vector3.Distance(transform.position, target.position) < 0.05f) {
      currentWayPoint++;

      if (currentWayPoint >= wayPoints.Length) {
        // Most likely will have this get destroyed and deal damage if it hits the base first
        Destroy(gameObject); // TEMP DESTRUCTION TO NOT FILL SCREEN WITH SHITE
      }
    }
  }

  void TakeDamage(int value) {
    health -= value;
    if (health <= 0) {
      // Call GameManager.AddCurrency(currencyValue) or something like that
      Destroy(gameObject);
    }
  }
}
