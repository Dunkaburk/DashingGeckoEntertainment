using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer _renderer;
    public GameObject player;
    public Collider2D enemyCollider;
    public Rigidbody2D rigidBody;

    public GameObject lootDrop;
    public bool IsDead
    {
        get => animator.GetBool("IsDead");
        set => animator.SetBool("IsDead", value);
    }
    bool IsMoving
    {
        get => animator.GetBool("IsMoving");
        set => animator.SetBool("IsMoving", value);
    }
    public float Health
    {
        get { return health; }
        set
        {
            health = value;

            if (health <= 0 && !IsDead)
            {
                Death();
            }
        }
    }

    public float health;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Collider2D playerCollider = player.GetComponent<Collider2D>();
        IsDead = false;
        IsMoving= false;

        Physics2D.IgnoreCollision(enemyCollider, playerCollider);
        _renderer = GetComponent<SpriteRenderer>();
        if (_renderer == null)
        {
            Debug.LogError("Enemy Sprite is missing a renderer");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead) {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01f)
            {
                IsMoving = true;
            }
            else
            {
                IsMoving = false;
            }


            if ((player.transform.position - transform.position).x > 0)
            {
                _renderer.flipX = false;
            }
            else
            {
                _renderer.flipX = true;
            }
        }
        
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(gameObject.name + " took " + damage + " damage");
        Health -= damage;
    }

    public void Death()
    {
        Debug.Log(gameObject.name + " Killed");
        IsDead = true;
        Instantiate(lootDrop, transform.position, Quaternion.identity);
        Debug.Log("Loot spawned");
        enemyCollider.enabled = false;
        rigidBody.velocity = Vector2.zero;
    }

}
