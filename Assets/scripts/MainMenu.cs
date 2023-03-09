using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class MainMenu : MonoBehaviour
{

    public GameObject SettingsPanel;
    public GameObject[] HowToPlayPanels;
    public GameManager GameManager;

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

        GameManager.coins = 0;
        GameManager.health = 100;
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

    public void CloseHowToPlay0()
    {
        HowToPlayPanels[0].SetActive(false);
    }

    public void CloseHowToPlay1()
    {
        HowToPlayPanels[1].SetActive(false);
    }


    public void CloseHowToPlay2()
    {
        HowToPlayPanels[2].SetActive(false);
    }


    public void OpenHowToPlay0()
    {
        HowToPlayPanels[0].SetActive(true);
    }


    public void OpenHowToPlay1()
    {
        HowToPlayPanels[1].SetActive(true);
    }


    public void OpenHowToPlay2()
    {
        HowToPlayPanels[2].SetActive(true);
    }



}
