using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatScript : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public Collider2D playerRectangleCollider;

    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCd = 0.3f;


    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKey(KeyCode.F) && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;
        }
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }

            else
            {
                attacking = false;
            }
        }
        animator.SetBool("isAttacking", attacking);
    }

    // Will handle if the player is hurt by an enemy or trap, requires Colliders
    private void GetAttacked()
    {

    }
}
