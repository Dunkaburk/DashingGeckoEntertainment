using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{

    private GameObject player;
    private interactableObject ib;
    private TimeManager tm;
    private bool lastinteraction = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        ib = this.gameObject.GetComponent<interactableObject>();
        tm = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ib.interacted)
        {
            tm.restartTime();
        }
    }
}
