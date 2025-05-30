using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MapMinigame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D myRigidBody;
    public float movementSpeed = 10f;
    private Vector2 movementDirection;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = UnityEngine.Input.GetAxisRaw("Horizontal");
        float inputY = UnityEngine.Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
        if (movementDirection.y > 0) //otaceni sneka kdyz leze do leva/do prava
        {
            transform.localScale = new Vector3(1, 1, 1); //nasobim tim direction multiplier aby se otacel spravne i kdyz je na strope

        }
        else if (movementDirection.y < 0)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }

    }

    private void FixedUpdate()
    {
        myRigidBody.linearVelocity = movementDirection * movementSpeed;
    }
}
