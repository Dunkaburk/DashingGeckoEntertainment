using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class MainMenu : MonoBehaviour
{

    public GameObject SettingsPanel;
    public GameObject[] HowtoPanel;

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
        SceneManager.LoadScene("ElevatorRoom");
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


    public void OpenHowTo(int i)
    {
        HowtoPanel[i].SetActive(true);
        if(i > 0)
        {
            CloseHowTo(i - 1);
        }
    }

    public void CloseHowTo(int i)
    {
        HowtoPanel[i].SetActive(false);
    }

    public void BackHowTo(int i)
    {
        HowtoPanel[i].SetActive(true);
        if (i < HowtoPanel.Length)
        {
            CloseHowTo(i + 1);
        }
    }
}
