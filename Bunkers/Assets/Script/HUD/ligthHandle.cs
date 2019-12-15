using UnityEngine;
using UnityEngine.UI;

public class ligthHandle : MonoBehaviour
{
    public bool chrono;
    public float timer;
    public int timeSpeed;
    public int timeSpeedNight;
    public Light lt;
    private float ligthtime;
    public int  dayCounter;
    public float hours;
    public float minutes;
    [SerializeField] private ScoreHandler   scoreHandler;

    // Start is called before the first frame update
    void Start()
    {
        dayCounter = 1;
        chrono = true;
    }
    // Update is called once per frame
    void Update()
    {
        int temp = (int)timer / 60;
        if (temp >= 6 && temp < 10)
        {
            if (ligthtime < 1.3)
                ligthtime += 0.00009f * timeSpeed;
        }
        if (temp == 12)
            ligthtime = 1.3f;
       if (temp > 19 && temp <= 22)
        {
            ligthtime -= 0.0002f * timeSpeedNight;
        }
        if (temp == 23)
            ligthtime = 0;
        lt.intensity = ligthtime;
        if (timer > 1440)
        {
            dayCounter++;
            timer = 0;
            scoreHandler.UpdateDay(dayCounter);
            //timeUIHandler.GetComponent<TimeUIHandler>().updateDay(dayCounter);
        }
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
            scoreHandler.UpdateHoursMinutes(hours, minutes);
            //timeUIHandler.GetComponent<TimeUIHandler>().updateTimer(hours, minutes);
        }
    }
}
