using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ChestScript : MonoBehaviour
{

    private interactableObject ib;
    private bool open = false;
    private Animator anim;
    public GameObject cs;
    public GameObject c;
    public GameObject pot;


    // Start is called before the first frame update
    void Start()
    {
        ib = this.gameObject.GetComponent<interactableObject>();
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ib.interacted && open == false)
        {
            open = true;
            anim.Play("Openingchest");
            ib.hideUI();
            Instantiate(cs, new Vector3(gameObject.transform.position.x+(float)0.01, gameObject.transform.position.y-(float)0.07, 0) , Quaternion.identity);
            Instantiate(c, new Vector3(gameObject.transform.position.x+(float)0.1, gameObject.transform.position.y-(float)0.07, 0) , Quaternion.identity);
            Instantiate(c, new Vector3(gameObject.transform.position.x-(float)0.08, gameObject.transform.position.y-(float)0.08, 0) , Quaternion.identity);
            Instantiate(pot, new Vector3(gameObject.transform.position.x + (float)0.08, gameObject.transform.position.y - (float)0.12, 0), Quaternion.identity);

        }
    }


}
