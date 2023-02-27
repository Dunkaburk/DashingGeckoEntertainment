using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObject : MonoBehaviour
{
    private GameObject player;
    public GameObject UIPrefab;
    public float distance = 10;
    public bool interacted = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        UIPrefab = Instantiate(UIPrefab, new Vector3(this.gameObject.transform.position.x + UIPrefab.GetComponent<SpriteRenderer>().bounds.size.x/2, this.gameObject.transform.position.y + UIPrefab.GetComponent<SpriteRenderer>().bounds.size.y/2, 0), Quaternion.identity);
        UIPrefab.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distance)
        {
            UIPrefab.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("shop keeper");
                interacted = true;
            }
        }

        else {
            UIPrefab.SetActive(false);

        }

    }
}
