using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRB : MonoBehaviour
{

    private float horizontal;
    private float speed = 7.5f;
    private float speedJumping = 1f;
    private float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        Move();
        if (IsGrounded())
        {
            
            speedJumping = 1f;
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            else if (animator.GetBool("Jump"))
            {
                animator.SetBool("Jump", false);
            }

        }
        else
        {
            speedJumping = 0.5f;
            animator.SetBool("Jump", true);
        }





    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetBool("Run_Right", horizontal > 0f);
        animator.SetBool("Run_Left", horizontal < 0f);
        rb.velocity = new Vector2(horizontal * speed * speedJumping, rb.velocity.y);
    }

    void Jump()
    {
        
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        animator.SetBool("Jump", true);
    }

    bool IsGrounded()
    {
        Vector3 origin = transform.position;
        origin.y -= 0.65f;
        Vector3 direction = Vector3.down;
        float maxDistance = 0.045f;

        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D rc = Physics2D.Raycast(origin, direction, maxDistance, mask);
        Debug.DrawRay(origin, direction * maxDistance, Color.red);

        bool grounded = rc.collider != null;

        return grounded;
    }

}
