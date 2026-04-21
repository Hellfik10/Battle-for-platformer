using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _attackRange = 1f;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyLayer;

    public bool IsAttacking { private set; get; } = false;

    public void Attack()
    {
        if (IsAttacking == false)
        {
            IsAttacking = true;

            DetectEnemies();
        }
    }

    public void EndAttack()
    {
        IsAttacking = false;
    }

    private void DetectEnemies()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.TryGetComponent<Health>(out var enemyHealth))
            {
                enemyHealth.TakeDamage(_damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (_attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
        }
    }
}

