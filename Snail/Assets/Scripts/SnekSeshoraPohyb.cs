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
        rb.freezeRotation = true; // Zamkne fyzikální otáèení, rotaci øídíme skriptem
    }

    void Update()
    {
        // Naèti vstup z klávesnice
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Otoèí objekt pouze pokud hráè nìco maèká
        if (movement.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f); // -90° pokud má sprite èumák nahoru
        }
    }

    void FixedUpdate()
    {
        // Pohyb pomocí linearVelocity (pokud to editor vyžaduje)
        rb.linearVelocity = movement.normalized * moveSpeed;
    }
}
