using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public Rigidbody rb;
    public Animator animator;
    public float jumpForce = 500f;
    public float rotationSpeed;
    Vector3 moveDirection;
    bool mustJump = false;
    bool isGrounded = true;


    public GameObject cameraObj;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        animator.SetBool("isRunning", rb.velocity.magnitude > 0.01f);


        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        float mouseMovX = Input.GetAxis("Mouse X");
        float mouseMovY = Input.GetAxis("Mouse Y");

        print(mouseMovX);
        print(mouseMovY);


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            mustJump = true;
        }

        transform.rotation = Quaternion.Euler(0, mouseMovX * rotationSpeed, 0) * transform.rotation;
        
        cameraObj.transform.localRotation = Quaternion.Euler(-mouseMovY * rotationSpeed, 0, 0) * cameraObj.transform.localRotation;

        //moveDirection = new Vector3(moveX, 0, moveZ).normalized * speed;
        moveDirection = (transform.forward * moveZ + transform.right * moveX).normalized * speed; 


        
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

    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
