using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;

    private Vector3 velocity = Vector3.zero;
    private float speed = 10f;
    private int movementDirection;

    private const int DERECHA = 1;
    private const int IZQUIERDA = -1;
    private const int QUIETO = 0;
    // Start is called before the first frame update
    void Start()
    {
        movementDirection = QUIETO;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Move(DERECHA);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(IZQUIERDA);
        }
        else
        {
            if (movementDirection == IZQUIERDA)
            {
                animator.SetBool("Run_Right", false);
                animator.SetBool("Run_Left", false);
                animator.SetBool("Idle_Left", true);
            }
            else if (movementDirection == DERECHA)
            {
                animator.SetBool("Run_Right", false);
                animator.SetBool("Run_Left", false);
                animator.SetBool("Idle_Right", true);
            }
            movementDirection = QUIETO;
            velocity = Vector3.zero;
        }

        transform.position += velocity * Time.deltaTime;
    }

    private void Move(int direction)
    {
        movementDirection = direction;

        if (direction == DERECHA) {

            animator.SetBool("Run_Right", true);
            animator.SetBool("Run_Left", false);
            animator.SetBool("Idle_Right", false);
            animator.SetBool("Idle_Left", false);
        }
        else if (direction == IZQUIERDA)
        {
            animator.SetBool("Run_Right", false);
            animator.SetBool("Run_Left", true);
            animator.SetBool("Idle_Right", false);
            animator.SetBool("Idle_Left", false);
        }

        /*Vector3 scale = transform.localScale;
        scale.x = direction;
        transform.localScale = scale;*/
        velocity = direction * Vector3.right * speed;
    }
}
