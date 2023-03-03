using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
using UnityEngine.Tilemaps;



public class DoorScript : MonoBehaviour
{
    //DoorScript is attached to each door and determines where each door leads to.

    public string sceneToLoad;
    public TilemapCollider2D tilemapCollider;
    public GameObject spawnPoint;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered door");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Loading " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
            
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        //find selected spawn point in scene       Currently not implemented
        //spawnPoint = GameObject.FindWithTag("SpawnPoint");
        //set player position to spawn point
        //GameObject.FindWithTag("Player").transform.position = spawnPoint.transform.position;
        //find tilemap collider
        tilemapCollider = GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
