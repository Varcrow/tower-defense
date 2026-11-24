using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public enum AttackType
    {
        Melee,
        Ranged
    }

    [Header("Tower Stats")]
    public float attackRange = 3f;
    public float attackDamage = 10f;
    public float attackSpeed = 1f;

    [Header("Attack Type")]
    public AttackType attackType;

    [Header("Projectile Settings")]
    public GameObject projectilePrefab;
    public Transform firePoint;

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
            if (attackType == AttackType.Melee)
            {
                //MeleeAttack();    *************These Will need to be fixed with your enemy code*************
            }
            else
            {
                RangedAttack();
            }

            attackTimer = 1f / attackSpeed;
        }
    }

    //private void MeleeAttack()
    //{
    //    //TestEnemyHealth enemyHealth =
    //        currentTarget.GetComponent<TestEnemyHealth>();        *************These Will need to be fixed with your enemy code*************

    //    if (enemyHealth != null)
    //    {
    //        enemyHealth.TakeDamage(attackDamage);
    //    }
    //}

    private void RangedAttack()
    {
        if (projectilePrefab == null || firePoint == null)
        {
            Debug.LogWarning("Projectile prefab or FirePoint missing!");
            return;
        }

        GameObject newProjectile = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity
        );

        Projectile projectile = newProjectile.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.SetTarget(currentTarget, attackDamage);
        }
    }
}