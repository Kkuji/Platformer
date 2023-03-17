using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class BaseAnimator : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _currentHealth;

    [SerializeField] protected Transform _attackPoint;
    [SerializeField] protected LayerMask _enemyLayer;
    [SerializeField] protected int _attackDamage;
    [SerializeField] protected float _attackRange;

    protected Animator _animatorChar;

    private void Awake()
    {
        _currentHealth = _health;
        _animatorChar = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _animatorChar.SetTrigger("Damaged");

        if (_currentHealth < 1)
        {
            Die();
        }
    }

    private void Die()
    {
        _animatorChar.SetBool("IsDead", true);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        enabled = false;
    }

    public abstract void Attack();
}