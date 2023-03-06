using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer _renderer;
    public GameObject player;
    bool IsDead => animator.GetBool("IsDead");
    public float Health
    {
        get { return health; }
        set
        {
            health = value;

            if (health <= 0)
            {
                Debug.Log("Enemy Killed");
                animator.SetBool("IsDead", IsDead);
            }
        }
    }

    public float health = 4;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsDead", false);

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
                animator.SetBool("IsMoving", true);
            }
            else
            {
                animator.SetBool("IsMoving", false);
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
        Debug.Log("Enemy took " + damage + " damage");
        Health -= damage;
    }

}
