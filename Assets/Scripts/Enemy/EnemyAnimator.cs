using UnityEngine;

public class EnemyAnimator : BaseAnimator
{
    public override void Attack()
    {
        animatorChar.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerAnimator>().TakeDamage(attackDamage);
        }
    }
}