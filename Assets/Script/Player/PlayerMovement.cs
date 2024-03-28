using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 _moveDirection = Vector2.zero;
    /// <summary>
    /// Speed movement of the player
    /// </summary>
    public float Speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = _moveDirection * Speed;
    }

    

}
