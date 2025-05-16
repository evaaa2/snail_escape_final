using UnityEngine;

public class SnailScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    private float movementSpeed = 10f;
    float horizontalMove = 0f;
    private Vector2 movementDirection;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {      
        horizontalMove = UnityEngine.Input.GetAxisRaw("Horizontal")* movementSpeed;
        movementDirection = new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (movementDirection.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementDirection.x<0)
        {
            transform.localScale = new Vector3(1, 1, 1);
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
        myRigidBody.linearVelocity = transform.rotation * movementDirection * movementSpeed;
    }


    // kod pro lezeni po stenach
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            transform.rotation = Quaternion.identity; // tzn. 0,0,0
        }
        else if (collision.collider.CompareTag("Left"))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        }
        else if (collision.collider.CompareTag("Right"))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        else if (collision.collider.CompareTag("Ceiling"))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
    }
}
