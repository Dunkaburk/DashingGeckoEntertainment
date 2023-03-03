using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            animator.SetFloat("Health", health);
            if (health <= 0)
            {
                Debug.Log("Enemy Killed");
                Die();
            }
            else if (health <= 3 && !isHurt)
            {
                isHurt = true;
                animator.SetTrigger("Hurt");
            }
        }
    }

    public float health = 4;
    private Animator animator;
    private bool isMoving = false;
    private bool isHurt = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01f)
        {
            isMoving = true;
            animator.SetBool("IsMoving", true);
        }
        else
        {
            isMoving = false;
            animator.SetBool("IsMoving", false);
        }
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Enemy took " + damage + " damage");
        Health -= damage;
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        StartCoroutine(DestroyAfterAnimation());
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length); // wait for animation to finish
        Destroy(gameObject); // destroy object after animation is finished
    }
}
