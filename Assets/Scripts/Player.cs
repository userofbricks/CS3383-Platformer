using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 10f;
    private bool isGrounded = false;
    private float minGroundY = 0.7f;

    public Rigidbody2D rb;
    private float moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = false;
        rb.linearVelocity = new Vector2 (moveInput * moveSpeed, rb.linearVelocity.y);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>().x;
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y >= minGroundY)
            {
                isGrounded = true;
                break;
            }
        }
    }
}
