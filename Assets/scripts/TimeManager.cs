using UnityEngine;

public class TimeManager : MonoBehaviour
{

    private bool updateTimer = false;
    public StatsManager statsManager;
    public float timeRemaining = 100;
    private float orgTime = 100;



    // Start is called before the first frame update
    void Start()
    {
        updateTimer = true;
        orgTime = timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if (updateTimer)
        {
            Debug.Log(timeRemaining);
            timeRemaining -= 1 * Time.deltaTime;
            statsManager.updateTimer((int)timeRemaining);
        }
    }

    public void pauseTime()
    {
        updateTimer = false;
    }

    public void starTime()
    {
        updateTimer = true;
    }

    public void restartTime()
    {
        timeRemaining = orgTime;
        updateTimer = true;
    }
}
