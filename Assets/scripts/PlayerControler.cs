using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float minGroundNormalY = 0.7f;

    Rigidbody2D rb;
    private float moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        isGrounded = false;
        rb.linearVelocity = new Vector2 (moveInput * moveSpeed, rb.linearVelocity.y);
    }

    public void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>().x;
    }

    public void OnJump(InputValue value) {
        if(value.isPressed && isGrounded) {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        foreach (ContactPoint2D contact in collision.contacts) {
            if(contact.normal.y >= minGroundNormalY) {
                isGrounded = true;
            }
        }
    }
}
