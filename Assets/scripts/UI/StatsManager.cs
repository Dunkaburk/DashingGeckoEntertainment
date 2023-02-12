using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public TMP_Text CoinsText;   
    public TMP_Text TimerText;
    public TMP_Text HealthText;

    // Start is called before the first frame update
    void Start()
    {
      

    }

    public void updateHealth(int health) {
        HealthText.text = health.ToString();
    }

    public void updateCoins(int coins) {
        CoinsText.text = coins.ToString();
    }

    public void updateTimer(int time) {
        TimerText.text = time.ToString();
    }
}
