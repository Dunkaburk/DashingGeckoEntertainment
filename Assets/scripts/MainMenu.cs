using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class MainMenu : MonoBehaviour
{

    public GameObject SettingsPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Debug.Log("Quitting Game");
            Application.Quit();
        }
    }

    public void StartGame()
    {
        Debug.Log("Loading floor 1");
        SceneManager.LoadScene("Floor01");
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void OpenSettings()
    {
        Debug.Log("Opening Settings");
        SettingsPanel.SetActive(true);
        
    }

    public void CloseSettings()
    {
        Debug.Log("Closing Settings");
        SettingsPanel.SetActive(false);
        
    }

}
