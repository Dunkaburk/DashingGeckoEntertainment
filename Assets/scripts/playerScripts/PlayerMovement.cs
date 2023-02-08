using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    private Animator animator;
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
        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.x != 0 || direction.y != 0)
        {
            SetAnimatorMovement(direction);
        }
        else
        {

        }
    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);
    }

}
