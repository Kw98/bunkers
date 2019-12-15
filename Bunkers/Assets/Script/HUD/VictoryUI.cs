using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryUI : MonoBehaviour
{
    [SerializeField] private Text scoreTextF;
    [SerializeField] private Text scoreTextS;
    [SerializeField] private Text scoreTextT;

    private void OnEnable() {
        ScoreHandler sh = GameObject.Find("HUD").GetComponent<ScoreHandler>();
        scoreTextF.text = sh.score.points.ToString("00000") + "pts\n" + sh.score.day.ToString() + "days " + sh.score.hour.ToString("00") + "h " + sh.score.min.ToString("00") + "min";
        scoreTextS.text = scoreTextF.text;
        scoreTextT.text = scoreTextF.text;
    }
}
