using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{

    private interactableObject ib;
    public float distance = 10;
    public GameObject panel;
    public GameObject[] speach;
    private bool interakting = false;
    private int intercount;

    // Start is called before the first frame update
    void Start()
    {
        ib = this.gameObject.GetComponent<interactableObject>();
        // reset timer 
        GameManager.time = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (ib.interacted)
        {
            interakting = true;
            //panel.SetActive(true);
        }

        if (interakting)
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                intercount++;
            }

            if (intercount <= 3 && intercount != 0)
            {
                Debug.Log(intercount);
                if(intercount > 1)
                    speach[intercount-2].SetActive(false);
                speach[intercount-1].SetActive(true);
            }
            else if (intercount == 4)
            {
                speach[intercount - 2].SetActive(false);
                panel.SetActive(true);
            }
        }

    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        interakting = false;
        intercount = 0;
        if (GameManager.haveWon)
        {
            speach[3].SetActive(true);
        }
    }

    public void AddTime(int amount)
    {
        if (GameManager.coins >= amount)
        {
            GameManager.coins -=amount;
            GameManager.startTime += 10;
        }
    }

    public void heal(int amount)
    {
        if (GameManager.coins >= amount)
        {
            Debug.Log("gere");
            GameManager.coins -= amount;
            GameManager.health = 100;
        }
    }

    public void buyPart(int amount)
    {
        if (GameManager.coins >= amount)
        {
            GameManager.coins -= amount;
            GameManager.haveWon = true;
        }
    }
}
