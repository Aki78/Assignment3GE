using UnityEngine;

public class KinematicWASDMovementRaw : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
         {
            moveDirection.y += 1;
         }
        else if (Input.GetKey(KeyCode.S))
         {
            moveDirection.y -= 1;
         }

        if (Input.GetKey(KeyCode.A))
         {
            moveDirection.x -= 1;
         }
        else if (Input.GetKey(KeyCode.D))
         {
            moveDirection.x += 1;
         }

        moveDirection.Normalize();
    }

    void MoveCharacter()
    {
        Vector2 moveAmount = moveDirection*moveSpeed*Time.deltaTime;
        rb.MovePosition(rb.position+moveAmount);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);

        Vector2 parallelMove = ProjectVector(moveDirection, contact.normal);

        moveDirection -= parallelMove;

        // renormalize the move direction
        if (moveDirection.sqrMagnitude > 0)
        {
            moveDirection.Normalize();
        }
    }

    private Vector2 ProjectVector(Vector2 a, Vector2 b)
    {
        return Vector2.Dot(a, b) / Vector2.Dot(b, b) * b;
    }
}

