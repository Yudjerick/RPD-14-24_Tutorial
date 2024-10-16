using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody rb;
    public float jumpForce = 500f;
    Vector3 moveDirection;
    bool mustJump = false;
    bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            mustJump = true;
        }

        moveDirection = new Vector3(moveX, 0, moveZ).normalized * speed;

        
    }

    private void FixedUpdate()
    {
        if (mustJump)
        {
            rb.AddForce(Vector3.up * jumpForce);
            mustJump = false;
        }
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        
    }
}
