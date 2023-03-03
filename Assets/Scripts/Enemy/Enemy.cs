using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Vector2 direction = (transform.position - player.transform.position).normalized;
            Flip(direction);

            EnemyAnimator enemyAnimator = GetComponent<EnemyAnimator>();
            enemyAnimator.Attack();
        }
    }

    private void Flip(Vector2 currentDirection)
    {
        if (currentDirection.x < 0)
            transform.eulerAngles = new Vector2(0, 180);

        if (currentDirection.x > 0)
            transform.eulerAngles = new Vector2(0, 0);
    }
}