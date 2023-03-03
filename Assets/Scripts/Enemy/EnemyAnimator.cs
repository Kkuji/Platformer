using UnityEngine;

public class EnemyAnimator : Character
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackRange;
    [SerializeField] private int _attackDamage;

    public override void Attack()
    {
        animatorChar.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerAnimator>().TakeDamage(_attackDamage);
        }
    }
}