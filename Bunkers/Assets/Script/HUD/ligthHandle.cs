using UnityEngine;
using UnityEngine.UI;

public class ligthHandle : MonoBehaviour
{
    public bool chrono;
    public float timer;
    public int timeSpeed;
    public int timeSpeedNight;
    public Light lt;
    public GameObject    timeUIHandler;
    private float ligthtime;
    private int  dayCounter;
    private float hours;
    private float minutes;

    // Start is called before the first frame update
    void Start()
    {
        dayCounter = 0;
        chrono = true;
    }
    // Update is called once per frame
    void Update()
    {
        int temp = (int)timer / 60;
        if (temp >= 6 && temp < 11)
            ligthtime += 0.0006f;
        else if (temp > 19 && temp <= 22)
            ligthtime -= 0.0015f;
        lt.intensity = ligthtime;
        if (timer > 1440)
            timer = 0;
        if (chrono) {
            if (temp >= 7 && temp <= 20)
            {
                timer += Time.deltaTime * timeSpeed;
            }
            else
            {
                timer += Time.deltaTime * timeSpeedNight;
            }
            hours = Mathf.Floor(timer / 60);
            minutes = Mathf.Floor(timer % 60);
            if (hours == 6 && timer % 60 < 0.1f) {
                dayCounter++;
                timeUIHandler.GetComponent<TimeUIHandler>().updateDay(dayCounter);
            }
            timeUIHandler.GetComponent<TimeUIHandler>().updateTimer(hours, minutes);
        }
    }
}
