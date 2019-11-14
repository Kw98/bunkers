using UnityEngine;
using UnityEngine.UI;

public class ligthHandle : MonoBehaviour
{
    public bool chrono;
    public float timer;
    public Text chronoText;
    public int timeSpeed;
    public Light lt;
    private float ligthtime;
    public Text daysText;
    public Light FlashLight;

    // Start is called before the first frame update
    void Start()
    {
        chrono = true;

    }
    // Update is called once per frame
    void Update()
    {
        int temp = (int)timer / 60;
        displayMoment(temp);
        if (temp >= 6 && temp < 11)
            ligthtime += 0.0006f;
        if (temp > 19 && temp <= 22)
            ligthtime -= 0.0015f;
        lt.intensity = ligthtime;
        if (timer > 1440)
        {
            timer = 0;
        }
        else if (chrono)
        {
            timer += Time.deltaTime * timeSpeed;
            string minutes = Mathf.Floor(timer / 60).ToString("00");
            chronoText.text = minutes + "H";
        }
    }

    void displayMoment(float time)
    {

        if (time >= 7 && time <= 20)
        {
            daysText.text = "days";
            FlashLight.intensity = 0;
        }
        else
        {
            daysText.text = "night";
            FlashLight.intensity = 1.5f;
        }
    }

}
