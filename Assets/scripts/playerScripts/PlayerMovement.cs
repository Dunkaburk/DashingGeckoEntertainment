using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    private Animator animator;

    private float lastPressed = 0f;
    private float currentPressed = 0f;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        Move();
        CheckSprint();
    }

    private void ReadInput()
    {
        direction = Vector2.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Player Going Up");
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Player Going Down");
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Player Going Left");
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Player Going Right");
            direction += Vector2.right;
        }
    }

    private void Move()
    {
        //transform.Translate(direction * speed * Time.deltaTime); Old code.
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);

        if (direction != Vector2.zero)
        {
            SetAnimatorMovement(direction);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);
    }

    private void CheckSprint()
    {
        currentPressed = Time.realtimeSinceStartup;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentPressed - lastPressed < 0.25f)
            {
                speed = 1.25f;
            }
            else
            {
                speed = 0.65f;
            }
            lastPressed = currentPressed;
        }
    }

}
