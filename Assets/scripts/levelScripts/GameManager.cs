using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int coins = 10;
    public static int health = 100; 
    public static int startTime = 120;
    public static int time = 120;
    public static int keys = 0; 
    public static float spawnPointx = 0;
    public static float spawnPointy = 0;
    //List to keep track of cleared rooms
    public static List<string> clearedRooms = new List<string>();
    // Start is called before the first frame update
    public static bool alldeadEnemies = false;
    void Start()
    {
        checkIfAlreadyCleared();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfCleared();
    }

    public static void AddClearedRoom(){
        clearedRooms.Add(SceneManager.GetActiveScene().name);
    }

    public static void checkIfCleared(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        alldeadEnemies = true;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].GetComponent<Enemy>().IsDead == false)
            {
                alldeadEnemies = false;
            }
        }
        if (alldeadEnemies)
        {
            AddClearedRoom();
        }
    }

    public static void checkIfAlreadyCleared(){
        if(clearedRooms.Contains(SceneManager.GetActiveScene().name)){
            //Destroy all enemies with enemy tag
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies){
                Destroy(enemy);
            }
        }
    }

}
