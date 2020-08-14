using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Properties
    Rigidbody3D rbody;

    //Movement
    public float speed;
    public float jumpForce;
    public float moveVelocity;

    void Start () 
    {
        rbody = GetComponent<Rigidbody3D>();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput () 
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (checkGrounded())
            {
                rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
                anim.SetTrigger("Jump");
            }
        }

        //Left Right Movement
        moveVelocity = Input.GetAxis("Horizontal") * speed;
        if (moveVelocity > 0) {
            isFacingRight = true;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } 
        if (moveVelocity < 0) {
            isFacingRight = false;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }

    }
        
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
    }
}