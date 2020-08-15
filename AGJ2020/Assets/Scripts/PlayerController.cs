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
    [SerializeField] float requiredDustSpeed = 3f;

    [SerializeField] ParticleSystem dustTrail;

    public Head head;

    private float speed;
    private float negativeSpeed;

    public bool playingGame = true;

    public float GetSpeed()
    {
        return speed;
    }

    public float GetNegativeSpeed()
    {
        return negativeSpeed;
    } 

    public void SetSpeed(float inSpeed)
    {
        speed = inSpeed;
    }

    public void SetNegativeSpeed(float inNegativeSpeed)
    {
        negativeSpeed = inNegativeSpeed;
    }

    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        head = GetComponentInChildren<Head>();
    }

    void Update()
    {
        if (playingGame)
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
            HandleDustTrail();
        }
        else
        {
            speed = 0;
            HandleDustTrail();
        }
			
    }

    private void HandleTilt()
    {
        float tilt = head.GetTilt(); //returns value between 0 (all the way down) and 1 (all the way up);
        float halfwayPoint = 0.5f;
        if (tilt > 0.5)
        {
            float tiltValue = (tilt - halfwayPoint) * tiltFactor;
            // if player is moving forward, decrease their speed. if player is moving backwards, increase it.
            if (speed > 0)
            {
                speed -= tiltValue*(speed/maxSpeed);
            } else {
                negativeSpeed += tiltValue*(negativeSpeed/maxSpeed);

                if (negativeSpeed > maxSpeed)
                    negativeSpeed = maxSpeed;

            }
        }
        else
        {
            float tiltValue = (halfwayPoint-tilt) * tiltFactor;
            // if player is moving forward, increase their speed. if player is moving backwards, decrease it.
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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {   
            if (checkGrounded())
            {
                rb.AddForce(Vector3.up*jumpForce);
            }
        }

        //Left Right Movement
        if (Input.GetKey(KeyCode.D) && negativeSpeed == 0)
        {
            if (negativeSpeed < 0.1)
                negativeSpeed = 0;

            if (speed < 0.1)
                speed = 0.1f;

            speed += speed * acceleration * Time.deltaTime;

            if (speed > maxSpeed)
                speed = maxSpeed;
        }

        else if (Input.GetKey(KeyCode.A) && speed == 0)
        {
            if (speed < 0.1)
                speed = 0;

            if (negativeSpeed < 0.1)
                negativeSpeed = 0.1f;

            negativeSpeed += negativeSpeed * acceleration * Time.deltaTime;

            if (negativeSpeed > maxSpeed)
                negativeSpeed = maxSpeed;
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

    //returns speed as a value between -1f and 1f
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

    private bool checkGrounded() {
        BoxCollider collider = GetComponent<BoxCollider>();
        float distToGround = collider.bounds.extents.y;
        return Physics.Raycast(
            transform.position,
            -Vector3.up,
            distToGround + 0.1f
        );
    }

    private void HandleDustTrail()
    {
        var emission = dustTrail.emission;
        emission.enabled = ((speed > requiredDustSpeed || negativeSpeed > requiredDustSpeed) && checkGrounded());
    }
}