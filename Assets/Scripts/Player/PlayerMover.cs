using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private LayerMask _layerTilemap;
    [SerializeField] private float _narrowBoxcast;
    [SerializeField] private float _jumpDistance;
    [SerializeField] private float _rayRange;
    [SerializeField] private float _speed;

    private BoxCollider2D _collider;
    private Rigidbody2D _rigidbody;
    private Vector2 _velocity;
    private float _direction;
    private bool _isGrounded;

    public Vector2 Velocity => _velocity;
    public bool IsGrounded => _isGrounded;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckIsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _direction = Input.GetAxisRaw("Horizontal");
        _velocity = new Vector2(_speed * _direction, _rigidbody.velocity.y);
        _rigidbody.velocity = _velocity;
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpDistance);
    }

    private void CheckIsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size - new Vector3(_narrowBoxcast, 0, 0), 0,
                                             Vector2.down, _rayRange, _layerTilemap);

        if (hit.collider != null)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }
}