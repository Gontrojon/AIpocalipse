using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
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
        if (Input.GetKey(KeyCode.D) && movementDirection != IZQUIERDA)
        {
            Move(DERECHA);

        }
        else if (Input.GetKey(KeyCode.A) && movementDirection != DERECHA)
        {
            Move(IZQUIERDA);
        }
        else
        {
            movementDirection = QUIETO;
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
            velocity = Vector3.zero;
        }

        transform.position += velocity * Time.deltaTime;
    }

    private void Move(int direction)
    {
        movementDirection = direction;
        animator.SetBool("Run", true);
        animator.SetBool("Idle", false);
        Vector3 scale = transform.localScale;
        scale.x = direction;
        transform.localScale = scale;
        velocity = direction * Vector3.right * speed;
    }
}
