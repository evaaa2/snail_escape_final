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
        myRigidBody.linearVelocity = movementDirection * movementSpeed;
    }
}
