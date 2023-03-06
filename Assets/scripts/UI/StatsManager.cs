using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;


public class StatsManager : MonoBehaviour
{
    public TMP_Text CoinsText;   
    public TMP_Text TimerText;
    public TMP_Text HealthText;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        updateCoins(GameManager.coins);
        updateHealth(GameManager.health);
        updateTimer(GameManager.time);
    }

    public void updateHealth(int health) {
        HealthText.text = health.ToString();
    }

    public void updateCoins(int coins) {
        CoinsText.text = coins.ToString();
    }

    public void updateTimer(int time) {
        TimerText.text = time.ToString();
        if (time == 0)
            SceneManager.LoadScene("GameOverScene");
    }
}
