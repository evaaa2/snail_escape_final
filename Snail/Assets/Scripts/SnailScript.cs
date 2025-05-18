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
    public bool isOnWall = false;

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
        /*if (isOnWall)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        else 
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }*/

        if (movementDirection.x > 0)
        {
            transform.localScale = new Vector3(directionMultiplier * -1, 1, 1);

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
            //rb.gravityScale = 1f;
            /*isOnCeiling = false;
            isOnWall = false;*/
        }
        else if (collision.collider.CompareTag("Left"))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            //rb.gravityScale = 0f;
            /*isOnCeiling = false;
            isOnWall = true;*/
        }
        else if (collision.collider.CompareTag("Right"))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            //rb.gravityScale = 0f;
            /*isOnCeiling = false;
            isOnWall = true;*/
        }
        else if (collision.collider.CompareTag("Ceiling"))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            //rb.gravityScale = 0f;
            /*isOnCeiling = true;
            isOnWall = false;*/
        }
        
        /*directionMultiplier = isOnCeiling ? -1f : 1f;*/

    }
}
