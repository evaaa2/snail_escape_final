using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Windows;

public class SnailScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public SpriteRenderer mySpriteRenderer;
    private float movementSpeed = 10f;
    float horizontalMove = 0f;
    private Vector2 movementDirection;
    public Animator animator;
    public bool isOnCeiling = false;
    public float directionMultiplier;

    public bool hasKey = false;

    //public bool isOnWall = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        float inputX = UnityEngine.Input.GetAxisRaw("Horizontal");
        float inputY = UnityEngine.Input.GetAxisRaw("Vertical");
        horizontalMove = UnityEngine.Input.GetAxisRaw("Horizontal") * movementSpeed;
        movementDirection = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // otaceni sneka a animace
        if (movementDirection.x > 0) //otaceni sneka kdyz leze do leva/do prava
        {
            transform.localScale = new Vector3(directionMultiplier * -1, 1, 1); //nasobim tim direction multiplier aby se otacel spravne i kdyz je na strope

        }
        else if (movementDirection.x < 0)
        {
            transform.localScale = new Vector3(directionMultiplier * 1, 1, 1);
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow) || UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("KeyDown", true);
        }
        else if (UnityEngine.Input.GetKeyUp(KeyCode.RightArrow) || UnityEngine.Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("KeyDown", false);
        }
    }

    void FixedUpdate()
    {
        myRigidBody.linearVelocity = transform.rotation * movementDirection * directionMultiplier * movementSpeed;
    }


    // kod pro lezeni po stenach
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            transform.rotation = Quaternion.identity; // tzn. 0,0,0
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            //uprava!!
            rb.gravityScale = 0f; //na zemi ma gravitaci rovnou 1
            isOnCeiling = false; //nastaveni, jestli je na zdi nebo na strope nebo normalne na zemi
            //isOnWall = false; //to isOnWall asi zatim neni potreba, nikde jsem to nakonec nepouzila
        }
        else if (collision.collider.CompareTag("Left"))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
            Rigidbody2D rb = GetComponent<Rigidbody2D>(); //uploaduju data rigidbody z te hry
            rb.gravityScale = 0f; //nastaveni gravitace na 0 - kdyz leze po stenach a strope
            isOnCeiling = false;
            //isOnWall = true;
        }
        else if (collision.collider.CompareTag("Right"))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
            isOnCeiling = false;
            //isOnWall = true;
        }
        else if (collision.collider.CompareTag("Ceiling"))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
            isOnCeiling = true;
            //isOnWall = false;
        }

        else if (collision.collider.CompareTag("Key"))
        {
            hasKey = true;
        }

        directionMultiplier = isOnCeiling ? -1f : 1f; //pokud je na strope, otoci se nejak ty vektory (z chata), nasobim tim pak ten pohyb a otaceni, aby se i na strope pohyboval realisticky (pretacel se v souladu se smerem)
    }
}
