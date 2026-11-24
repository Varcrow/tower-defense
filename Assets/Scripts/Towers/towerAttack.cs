using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [Header("Tower Stats")]
    public float attackRange = 3f;
    public float attackDamage = 10f;
    public float attackSpeed = 1f;

    [Header("Enemy Detection")]
    public LayerMask enemyLayer;

    private Transform currentTarget;
    private float attackTimer = 0f;

    private void Update()
    {
        FindTarget();

        if (currentTarget != null)
        {
            AttackTarget();
        }
    }

    private void FindTarget()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(
            transform.position,
            attackRange,
            enemyLayer
        );

        if (enemies.Length > 0)
        {
            currentTarget = enemies[0].transform;
        }
        else
        {
            currentTarget = null;
        }
    }

    private void AttackTarget()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
        {
            TestEnemyHealth enemyHealth =
                currentTarget.GetComponent<TestEnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);

                Debug.Log(gameObject.name + " attacked " + currentTarget.name);
            }

            attackTimer = 1f / attackSpeed;
        }
    }
}
