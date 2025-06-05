using UnityEngine;

public class SnekSeshoraPohyb : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true; // Zamkne fyzik�ln� ot��en�, rotaci ��d�me skriptem
    }

    void Update()
    {
        // Na�ti vstup z kl�vesnice
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Oto�� objekt pouze pokud hr�� n�co ma�k�
        if (movement.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f); // -90� pokud m� sprite �um�k nahoru
        }
    }

    void FixedUpdate()
    {
        // Pohyb pomoc� linearVelocity (pokud to editor vy�aduje)
        rb.linearVelocity = movement.normalized * moveSpeed;
    }
}
