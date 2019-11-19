using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUIHandler : MonoBehaviour {
    [SerializeField] private Text   dayMain;
    [SerializeField] private Text   daySecond;
    [SerializeField] private Text   dayThird;

    [SerializeField] private Text   timerMain;
    [SerializeField] private Text   timerSecond;
    [SerializeField] private Text   timerThird;

    public void updateDay(int day) {
        string d = "day  ";
        if (day > 1)
            d = "days  ";
        d += day.ToString();
        dayMain.text = d;
        daySecond.text = d;
        dayThird.text = d;
    }

    public void updateTimer(float hours, float minutes) {
        string t = hours.ToString("00") + "h " + minutes.ToString("00") + "min";
        timerMain.text = t;
        timerSecond.text = t;
        timerThird.text = t;
    }
}
