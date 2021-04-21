using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10;
    public float gravity = -9.81f;

    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public float jumps = 2;
    public LayerMask groundMask;
    public float jumpHeight = 3.0f;

    public float dashDuration = 1.0f;
    public float dashTime = 0.1f;
    public float dashSpeed = 10.0f;

    public bool leanRight = false;
    public bool leanLeft = false;
    public float leanOffset = 15.0f;


    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {

        //Uses mask to check if player is on ground level
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        //Sprint function
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 8;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            jumps = 2;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        //Move forward, backwards, left or right
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }


        if (Input.GetButtonDown("Jump") && !isGrounded && jumps < 1)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            jumps++;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
