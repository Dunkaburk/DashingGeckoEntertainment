using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObject : MonoBehaviour
{
    private GameObject player;
    public GameObject UIPrefab;
    public float distance = 10;
    public bool interacted = false;
    public float x= 0, y= 0;
    private bool hideUIb = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        UIPrefab = Instantiate(UIPrefab, new Vector3(this.gameObject.transform.position.x + UIPrefab.GetComponent<SpriteRenderer>().bounds.size.x/2+x, this.gameObject.transform.position.y + y + UIPrefab.GetComponent<SpriteRenderer>().bounds.size.y/2, 0), Quaternion.identity);
        UIPrefab.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distance && hideUIb == false)
        {
            UIPrefab.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                interacted = true;
            }
            else if(Input.GetKeyUp(KeyCode.E))
            {
                interacted = false;

            }
        }
        else
        {
            UIPrefab.SetActive(false);
        }
    }


    public void hideUI()
    {
        hideUIb = true;
        UIPrefab.SetActive(false);

    }
}
