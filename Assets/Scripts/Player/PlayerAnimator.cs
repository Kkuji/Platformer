using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerAnimator : BaseAnimator
{
    [SerializeField] private float _attackFrequency;

    private PlayerMover _playerMover;
    private float _lastAttackTime;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _lastAttackTime = -_attackFrequency;
    }

    private void Update()
    {
        if (!_playerMover.IsGrounded)
        {
            Jump();
        }
        else
        {
            Run();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Time.time >= _lastAttackTime + _attackFrequency)
            {
                Attack();
                _lastAttackTime = Time.time;
            }
        }
    }

    private void Run()
    {
        animatorChar.SetBool("Jump", false);
        Vector2 velocity = _playerMover.Velocity;

        if (velocity.x == 0)
        {
            animatorChar.SetBool("Run", false);
        }
        else
        {
            animatorChar.SetBool("Run", true);
            Flip(velocity);
        }
    }

    private void Jump()
    {
        Vector2 velocity = _playerMover.Velocity;

        animatorChar.SetBool("Jump", true);
        Flip(velocity);
    }

    public override void Attack()
    {
        animatorChar.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyAnimator>().TakeDamage(attackDamage);
        }
    }

    private void Flip(Vector2 velocity)
    {
        if (velocity.x < 0 && transform.eulerAngles.y != 180)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if (velocity.x > 0 && transform.eulerAngles.y != 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
    }
}