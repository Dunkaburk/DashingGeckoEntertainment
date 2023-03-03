using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    Vector2 rightAttackOffset;
    public float verticalOffset;

    public float damage = 3f;

    public enum AttackDirection
    {
        Right,
        Left,
        Up,
        Down
    }

    public AttackDirection attackDirection;
    // Start is called before the first frame update
    void Start()
    {
        swordCollider.enabled = false;
        rightAttackOffset = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(){
        switch(attackDirection){
            case AttackDirection.Right:
                AttackRight();
                break;
            case AttackDirection.Left:
                AttackLeft();
                break;
            case AttackDirection.Up:
                AttackUp();
                break;
            case AttackDirection.Down:
                AttackDown();
                break;
        }
    }

    private void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    private void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(-rightAttackOffset.x, rightAttackOffset.y);
    }

    private void AttackUp()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(0, rightAttackOffset.y + verticalOffset);
    }

    private void AttackDown()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(0, rightAttackOffset.y - verticalOffset);
    }

    public void StopAttack()
    {
        swordCollider.enabled = !swordCollider.enabled;
        Debug.Log("Attack Stopped");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            SlimeScript enemy = collision.GetComponent<SlimeScript>();
            if (enemy != null)
            {
                Debug.Log(enemy.health);
                enemy.TakeDamage(damage);
                Debug.Log("Enemy Hit for " + damage + " damage");

            }
            else {
                Debug.Log("Enemy not found");
            }
        }
    }

    


}
