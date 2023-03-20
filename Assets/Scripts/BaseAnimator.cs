using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class BaseAnimator : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;

    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected LayerMask enemyLayer;
    [SerializeField] protected int attackDamage;
    [SerializeField] protected float attackRange;

    protected Animator animatorChar;

    private void Awake()
    {
        _currentHealth = _health;
        animatorChar = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        animatorChar.SetTrigger("Damaged");

        if (_currentHealth < 1)
        {
            Die();
        }
    }

    private void Die()
    {
        animatorChar.SetBool("IsDead", true);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        enabled = false;
    }

    public abstract void Attack();
}