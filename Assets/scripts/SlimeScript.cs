using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public CircleCollider2D slimeCircleCollider;


    public float Health {
        get { return Health; }
        set { 
            Health = value; 
            if (Health <= 0)
            {
                Debug.Log("Slime Killed");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
