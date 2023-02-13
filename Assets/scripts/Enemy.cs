using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Health {
        get { return health; }
        set { 
            health = value; 
            if (health <= 0)
            {
                Debug.Log("Enemy Killed");
                Die();
            }
        }
    }
    public float health = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Enemy took " + damage + " damage");
        Health -= damage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
