using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    float horizontalMove = 0f;
    private Vector2 movementDirection;
    public Animator animator;
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        //the snail should not jump
        moveY = 0;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        transform.position += new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;

        if (movementDirection.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementDirection.x < 0)
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
        myRigidBody.linearVelocity = movementDirection * speed;
    }
}
