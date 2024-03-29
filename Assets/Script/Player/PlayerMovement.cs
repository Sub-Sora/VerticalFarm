using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 _moveDirection = Vector2.zero;
    private SpriteRenderer _spriteRenderer;
    private Animator _anim;
    /// <summary>
    /// Speed movement of the player
    /// </summary>
    public float Speed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = _moveDirection * Speed;
        // Start anim + change direction to right side
        if (_moveDirection.x > 0)

        {
            _spriteRenderer.flipX = true;
            _anim.SetBool("IsWalk", true);
        }
        // Start anim + change direction to left side
        else if (_moveDirection.x < 0)

        {
            _spriteRenderer.flipX = false;
            _anim.SetBool("IsWalk", true);
        }
        if (_moveDirection.x == 0) _anim.SetBool("IsWalk", false);
    }

}
