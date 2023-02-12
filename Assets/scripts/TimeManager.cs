using UnityEngine;

public class TimeManager : MonoBehaviour
{

    private bool updateTimer = false;
    public StatsManager statsManager;
    public float timeRemaining = 10;
    public float orgTime = 10;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (updateTimer)
        {
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
    }
}
