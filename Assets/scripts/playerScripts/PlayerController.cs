using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerController : MonoBehaviour
{
    //Relevant game objects
    public Vector2 direction;
    private Animator animator;

    public Rigidbody2D rb;
    public Collider2D playerRectangleCollider;

    //Variables for character stats
    public float speed;

    //Character abilities
    public SwordAttack swordAttack;


    //Variables for key presses
    private float lastPressed = 0f;
    private float currentPressed = 0f;

    //Variables relevant to attack move
    private float attackTimer = 0;
    private float attackCd = 0.3f;


    //Variables to keep track of states
    private bool attacking = false;
    private bool canMove = true;

    //Variables to keep track of previous values
    private Vector2 previousDirection = Vector2.zero;
    private Vector2 previousVelocity = Vector2.zero;
    private float previousSpeed = 0f;

    bool IsDead
    {
        get => animator.GetBool("IsDead");
        set => animator.SetBool("IsDead", value);
    }
    bool IsMoving
    {
        get => animator.GetBool("IsMoving");
        set => animator.SetBool("IsMoving", value);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        IsDead = false;
        IsMoving = false;
    }

    // Update is called once per frame, Note: Can use FixedUpdate for things that should only happen a couple of times per second
    void Update()
    {
        ReadMoveInput();
        CheckSprint();
        Move();
        Attack();
        CheckHealth();

    }

     private void ReadMoveInput()
    {
        if (canMove) {
            direction = Vector2.zero;
            
            if (Input.GetKey(KeyCode.W))
            {
                //Debug.Log("Player Going Up");
                direction += Vector2.up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                //Debug.Log("Player Going Down");
                direction += Vector2.down;
            }
            if (Input.GetKey(KeyCode.A))
            {
                //Debug.Log("Player Going Left");
                direction += Vector2.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                //Debug.Log("Player Going Right");
                direction += Vector2.right;
            }
        }
        else 
        {
            direction = Vector2.zero;
            rb.velocity = Vector2.zero;
        }
    }

    private void disableAttackCollider()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Attack Collider Disabled");
            swordAttack.ActiveAttack = !swordAttack.ActiveAttack;
            swordAttack.swordCollider.enabled = false;
            
        }
    }

    private void CheckHealth()
    {
        if (GameManager.health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        IsDead = true;
        canMove = false;
        Debug.Log("Player is dead");
        StartCoroutine(LoadAfterDelay(4));
        
    }

    IEnumerator LoadAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOverScene");
    }

    private void Move()
    {
        if (canMove) {
            //transform.Translate(direction * speed * Time.deltaTime); Old code.
            //rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
            rb.velocity = direction.normalized * speed; // Normalizes the speed by setting magnitude to 1, even during diagonal movement

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
    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);
    }

    private void CheckSprint()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                speed = 1.25f;
            }
        }
        else
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

// ------------------ Previously; PlayerCombatScript.cs, handles player combat ------------------
    private void Attack()
    {
        if (!attacking )
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                swordAttack.attackDirection = SwordAttack.AttackDirection.Up;
                attacking = true;
                swordAttack.ActiveAttack = true;
                attackTimer = attackCd;
                previousDirection = direction;
                animator.SetFloat("xDir", 0);
                animator.SetFloat("yDir", 1);
                Debug.Log("Player Attack Up");
                swordAttack.Attack();

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                swordAttack.attackDirection = SwordAttack.AttackDirection.Down;
                attacking = true;
                swordAttack.ActiveAttack = true;
                attackTimer = attackCd;
                previousDirection = direction;
                animator.SetFloat("xDir", 0);
                animator.SetFloat("yDir", -1);
                Debug.Log("Player Attack Down");
                swordAttack.Attack();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                swordAttack.attackDirection = SwordAttack.AttackDirection.Left;
                attacking = true;
                swordAttack.ActiveAttack = true;
                attackTimer = attackCd;
                previousDirection = direction;
                animator.SetFloat("xDir", -1);
                animator.SetFloat("yDir", 0);
                Debug.Log("Player Attack Left");
                swordAttack.Attack();
                
                }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                swordAttack.attackDirection = SwordAttack.AttackDirection.Right;
                attacking = true;
                swordAttack.ActiveAttack = true;
                attackTimer = attackCd;
                previousDirection = direction;
                animator.SetFloat("xDir", 1);
                animator.SetFloat("yDir", 0);
                Debug.Log("Player Attack Right");
                swordAttack.Attack();

            }
            
        }

        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else
        {
            attacking = false;
        }
        
        
        animator.SetBool("isAttacking", attacking);

    }
    //--------

    public void lockMovement()
    {
        previousSpeed = speed;
        previousVelocity = rb.velocity;
        canMove = false;
    }
    public void unlockMovement()
    {
        canMove = true;
        animator.SetFloat("xDir", previousDirection.x);
        animator.SetFloat("yDir", previousDirection.y);
        direction = previousDirection;
        speed = previousSpeed;
        rb.velocity = previousVelocity;
        swordAttack.StopAttack();
        swordAttack.ActiveAttack = false;
    }

    //----------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null && enemy.IsDead == false && playerRectangleCollider.bounds.Intersects(collision.bounds) && collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.name == "Slime")
            {
                GameManager.health -= 20;
                Debug.Log("Player Hit for 20 damage, Player Health: " + GameManager.health);
                TakeKnockback();
            }
            else if (collision.gameObject.name == "Orc")
            {
                GameManager.health -= 40;
                Debug.Log("Player Hit for 20 damage, Player Health: " + GameManager.health);
                TakeKnockback();
            }
        }
    }

    private void TakeKnockback()
    {
        lockMovement();
        //apply force in opposite direction of enemy. Currently only sends player in opposite direction of last movement.
        rb.AddForce(-direction * 200);        
        unlockMovement();
    }



}
