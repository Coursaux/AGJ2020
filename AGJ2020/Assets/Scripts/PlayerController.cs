using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Properties
    Rigidbody rb;

    //Movement
    public float acceleration;
    public float maxSpeed;
    public float jumpForce;
    public float friction;

    [SerializeField] float tiltFactor = 0.1f;

    Head head;

    private float speed;
    private float negativeSpeed;

    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        head = GetComponentInChildren<Head>();
    }

    void Update()
    {
        HandleInput();
        HandleTilt();
        if (speed > 0)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else 
        {
            transform.position -= transform.right * negativeSpeed * Time.deltaTime;
        }
        print(speed);
    }

    private void HandleTilt()
    {
        float tilt = head.GetTilt();
        if (tilt > 0.5)
        {
            float tiltValue = (tilt - 0.5f) * tiltFactor;
            if (speed > 0)
            {
                speed -= tiltValue*(speed/maxSpeed);
            } else {
                negativeSpeed += tiltValue*(negativeSpeed/maxSpeed);
            }
        }
        else
        {
            float tiltValue = (0.5f-tilt) * tiltFactor;
            if (speed > 0)
            {
                negativeSpeed -= tiltValue * (negativeSpeed / maxSpeed);
            }
            else
            {
                speed += tiltValue*(speed / maxSpeed);
            }
        }
    }

    void HandleInput () 
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {/*
            if (checkGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }*/
        }

        //Left Right Movement
        if (Input.GetKey(KeyCode.D) && negativeSpeed == 0)
        {
            if (negativeSpeed < 0.1)
                negativeSpeed = 0;

            if (speed < 0.1)
                speed = 0.1f;

            speed += speed * acceleration * Time.deltaTime;

            if (speed > 10)
                speed = 10f;
        }

        else if (Input.GetKey(KeyCode.A) && speed == 0)
        {
            if (speed < 0.1)
                speed = 0;

            if (negativeSpeed < 0.1)
                negativeSpeed = 0.1f;

            negativeSpeed += negativeSpeed * acceleration * Time.deltaTime;

            if (negativeSpeed > 10)
                negativeSpeed = 10f;
        }

        else
        {
            if (speed < 1)
                speed = 0;

            if (negativeSpeed < 1)
                negativeSpeed = 0;

            speed -= speed * friction * Time.deltaTime;
            negativeSpeed -= negativeSpeed * friction * Time.deltaTime;
        }
    }

    public float GetSpeedFactor()
    {
        if (speed > 0)
        {
            return speed / maxSpeed;
        } else
        {
            return -(negativeSpeed / maxSpeed);
        }
    }

    /*  
    //Check if Grounded 
    private bool checkGrounded() {
        float distToGround = GetComponent<CapsuleCollider2D>().bounds.extents.y;
        RaycastHit2D collision = Physics2D.Raycast(
            transform.position, 
            Vector2.down, 
            distToGround + 0.1f, 
            LayerMask.GetMask("Ground")
        );

        return (collision.collider != null);
    }*/
}