using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{

    private interactableObject ib;
    public float distance = 10;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        ib = this.gameObject.GetComponent<interactableObject>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ib.interacted)
        {
            panel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void AddTime()
    {

    }

    public void heal()
    {

    }

    public void addSpeed()
    {

    }
}
