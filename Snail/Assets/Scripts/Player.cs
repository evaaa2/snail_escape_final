using UnityEngine;

public class Player : MonoBehaviour
{
    //public variables
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

        transform.position += new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;
    }
}
