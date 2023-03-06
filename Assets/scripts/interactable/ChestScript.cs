using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{

    private interactableObject ib;
    private bool open = false;
    private Animator anim;

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
            anim.Play("chestAnimation");
            ib.hideUI();
        }
    }
}
