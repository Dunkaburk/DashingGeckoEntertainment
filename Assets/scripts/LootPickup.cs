using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPickup : MonoBehaviour
{
    public int pickupQuantity;
    public enum pickupObject {COIN, KEY};
    public pickupObject currentObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch(currentObject)
            {
                case pickupObject.COIN:
                    GameManager.coins += pickupQuantity;
                    Debug.Log("Coins picked up");
                    break;
                case pickupObject.KEY:
                    GameManager.keys += pickupQuantity;
                    Debug.Log("Key picked up");
                    break;
                default:
                    Debug.LogError("Invalid pickupObject");
                    break;
            }
            Destroy(gameObject);
        }
    }
}
