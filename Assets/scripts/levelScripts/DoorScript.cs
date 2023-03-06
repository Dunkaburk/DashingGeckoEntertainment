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
    public float spawnPointx;
    public float spawnPointy;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered door");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Loading " + sceneToLoad);
            GameManager.spawnPointx = spawnPointx;
            GameManager.spawnPointy = spawnPointy;
            SceneManager.LoadScene(sceneToLoad);
            
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        //set player position to spawn point
        GameObject player = GameObject.Find("Player");
        player.transform.position = new Vector2(GameManager.spawnPointx, GameManager.spawnPointy);

        //find tilemap collider
        tilemapCollider = GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
