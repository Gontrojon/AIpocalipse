using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Trigger : MonoBehaviour
{
    public Animator animator;

    private Vector3 velocity = Vector3.zero;
    private float speed = 10f;
    private int movementDirection;
    private PlayerState state;

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
        Debug.Log(Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Horizontal") > 0)
        {
            Move(Input.GetAxis("Horizontal"), DERECHA);

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Move(Input.GetAxis("Horizontal"), IZQUIERDA);
        }
        else
        {
            if (movementDirection == IZQUIERDA)
            {
                SetState(PlayerState.Idle_Left);
            }
            else if (movementDirection == DERECHA)
            {
                SetState(PlayerState.Idle_Right);
            }
            movementDirection = QUIETO;
            velocity = Vector3.zero;
        }

        transform.position += velocity * Time.deltaTime;
    }

    private void Move(float Vel, int direccion)
    {
        movementDirection = direccion;
        if (movementDirection == DERECHA) {

            SetState(PlayerState.Run_Right);
        }
        else if (movementDirection == IZQUIERDA)
        {
            SetState(PlayerState.Run_Left);
        }

        /*Vector3 scale = transform.localScale;
        scale.x = direction;
        transform.localScale = scale;*/
        velocity = Vel * Vector3.right * speed;
    }
    private void SetState(PlayerState newState)
    {
        if (state != newState)
        {
            animator.ResetTrigger("Idle_Left");
            animator.ResetTrigger("Idle_Right");
            animator.ResetTrigger("Run_Left");
            animator.ResetTrigger("Run_Right");
            state = newState;
            animator.SetTrigger($"{state}");
            //print($"triguereado el estado: {state}");
        }
    }
}
public enum PlayerState
{
    Idle_Left,
    Idle_Right,
    Run_Left,
    Run_Right,
    Jump,
    Fall,
    Push
}