using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float speed = 6f;

    [Header("Rotation Settings")]
    public bool spinProjectile = false;
    public float rotationSpeed = 180f;
    public float rotationOffset = 0f;

    private Transform target;
    private float damage;

    public void SetTarget(Transform newTarget, float newDamage)
    {
        target = newTarget;
        damage = newDamage;
    }

    private void Update()
    {
        // Destroy projectile if target no longer exists
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Calculate direction toward the enemy
        Vector2 direction = target.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Handle projectile rotation
        if (spinProjectile)
        {
            // Spin continuously (GOD projectile)
            transform.Rotate(
                0,
                0,
                rotationSpeed * Time.deltaTime
            );
        }
        else
        {
            // Face the enemy (Archer and Magic)
            transform.rotation = Quaternion.Euler(
                0,
                0,
                angle + rotationOffset
            );
        }

        // Move toward the enemy
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // Check if projectile reached the enemy
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            //HitTarget(); *************These Will need to be fixed with your enemy code*************
        }
    }

    //private void HitTarget()
    //{
    //    TestEnemyHealth enemyHealth =
    //        target.GetComponent<TestEnemyHealth>();                   *************These Will need to be fixed with your enemy code*************

    //    if (enemyHealth != null)
    //    {
    //        enemyHealth.TakeDamage(damage);
    //    }

    //    Destroy(gameObject);
    //}
}
