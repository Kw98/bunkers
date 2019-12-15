using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private Text   timeTextF;
    [SerializeField] private Text   timeTextS;
    [SerializeField] private Text   timeTextT;
    [SerializeField] private ScoreHandler   scoreHandler;

    void Start() {
        UpdateText(scoreHandler.score);
    }

    void Update() {
        UpdateText(scoreHandler.score);
    }

    private void UpdateText(Score score) {
        timeTextF.text = "day" + score.day.ToString() + ", " + score.hour.ToString("00") + "h " + score.min.ToString("00") + "min";
        timeTextS.text = timeTextF.text;
        timeTextT.text = timeTextF.text;
    }
}
