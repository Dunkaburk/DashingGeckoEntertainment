using UnityEngine;

public class TimeManager : MonoBehaviour
{

    private bool updateTimer = false;
    public StatsManager statsManager;
    public float timeRemaining;
    private float orgTime = 100;
    public GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        updateTimer = true;
        timeRemaining = GameManager.time;
        orgTime = timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if (updateTimer)
        {
            timeRemaining -= 1 * Time.deltaTime;
            GameManager.time = (int)timeRemaining;
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
        Debug.Log("here");
        GameManager.time = GameManager.startTime;
        timeRemaining = GameManager.time;
        updateTimer = true;
    }
}
