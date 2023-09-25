using UnityEngine;

public class KinematicWASDMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        print("starting");
    }

    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    void HandleInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
    }

    void MoveCharacter()
    {
        Vector2 moveAmount = moveDirection * moveSpeed * Time.fixedDeltaTime;
        
        rb.MovePosition(rb.position + moveAmount);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print("Collided");
        ContactPoint2D contact = collision.GetContact(0);

        Vector2 parallelMove = ProjectVector(moveDirection, contact.normal);

        moveDirection -= parallelMove;

        if(moveDirection.sqrMagnitude > 0)
        {
            moveDirection.Normalize();
        }
    }

    private Vector2 ProjectVector(Vector2 a, Vector2 b)
    {
        print("Calculating projection");
        return Vector2.Dot(a, b)/Vector2.Dot(b, b) * b;
    }
}
