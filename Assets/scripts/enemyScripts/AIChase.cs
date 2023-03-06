using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public Vector2 direction;
    private Animator animator;
    bool IsMoving {
        get => animator.GetBool("IsMoving");
        set => animator.SetBool("IsMoving", value);
        }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        IsMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("IsDead") == false)
        {
            distance = Vector2.Distance(transform.position, player.transform.position); // Checks the distance between the Enemy and the player
            direction = player.transform.position - transform.position;

            if (distance < 1.5) // If player is close to Enemy
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); // Follow the player
            }

            Move();
        }
    }

    private void Move()
    {
        if (direction != Vector2.zero)
        {
            SetAnimatorMovement(direction);
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetFloat("xDir", direction.x);
    }
}
