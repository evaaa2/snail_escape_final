using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SnailController : MonoBehaviour
{
    public float moveSpeed = 10f; // Toto nastavujte v Inspectoru, ne zde!
    public Transform spriteTransform; // Odkaz na tramsformaci obrazku sneka.

    private Rigidbody2D rb; // Odkaz na Rigidbody2D komponentu.
    private Vector2 currentLeft = Vector2.left; // Jaky smer je pro sneka aktualne jeho vlevo. Vychoze "normalni" vlevo.

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Ziskani odkazu na Rigidbody2D komponentu.
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0) spriteTransform.localScale = new Vector3(-1, 1, 1); // Pokud se snek hybe doprava, otocime jeho obrazek.
        else if (Input.GetAxisRaw("Horizontal") < 0) spriteTransform.localScale = new Vector3(1, 1, 1); // Pokud se snek hybe doleva, otocime jeho obrazek zpet.
    }

    private void FixedUpdate()
    {
        // Rychlost = Input ze sipek * rychlost * aktualni smer vlevo + konstantni gravitace smerem ke snekove smeru "dolu" -> vektor kolmy na aktualni vlevo.
        rb.linearVelocity = -Input.GetAxisRaw("Horizontal") * moveSpeed * currentLeft + new Vector2(-currentLeft.y, currentLeft.x);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // U kazde kolize nastavime spravne aktualni smer vlevo a otocime obrazek sneka.
        if (collision.collider.CompareTag("Floor"))
        {
            currentLeft = Vector2.left;
            spriteTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (collision.collider.CompareTag("Left"))
        {
            currentLeft = Vector2.up;
            spriteTransform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (collision.collider.CompareTag("Right"))
        {
            currentLeft = Vector2.down;
            spriteTransform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (collision.collider.CompareTag("Ceiling"))
        {
            currentLeft = Vector2.right;
            spriteTransform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
