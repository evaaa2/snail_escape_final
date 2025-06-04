using UnityEngine;

public class SnekSeshoraPohyb : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Just in case you forgot
    }

    void Update()
    {
        // Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Rotate only if moving
        if (movement.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
            // "-90" assumes sprite faces up by default, adjust if needed
        }
    }

    void FixedUpdate()
    {
        // Move the object
        rb.linearVelocity = movement.normalized * moveSpeed;
    }
}
