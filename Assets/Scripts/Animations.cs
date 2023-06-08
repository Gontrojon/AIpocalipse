using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move;
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
            Vector3 changedirection = transform.localScale;
            changedirection.x = -1;
            transform.localScale = changedirection;
            move = Vector3.right * Time.deltaTime * 10;
        }else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
            Vector3 changedirection = transform.localScale;
            changedirection.x = 1;
            transform.localScale = changedirection;
            move = Vector3.left * Time.deltaTime * 10;
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
            move = Vector3.zero;
        }

        transform.position += move;
    }
}
