using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private Text   playerTextF;
    [SerializeField] private Text   playerTextS;
    [SerializeField] private Text   playerTextT;
    [SerializeField] private Text   pointsTextF;
    [SerializeField] private Text   pointsTextS;
    [SerializeField] private Text   pointsTextT;
    [SerializeField] private Text   timeTextF;
    [SerializeField] private Text   timeTextS;
    [SerializeField] private Text   timeTextT;
    [SerializeField] private Text   rankTextF;
    [SerializeField] private Text   rankTextS;
    [SerializeField] private Text   rankTextT;

    public void InitScoreViewer(string playerName, int points, float time, int rank) {
        playerTextF.text = playerName;
        playerTextS.text = playerTextF.text;
        playerTextT.text = playerTextF.text;
        pointsTextF.text = points.ToString("00000") + " pts";
        pointsTextS.text = pointsTextF.text;
        pointsTextT.text = pointsTextF.text;
        if (time > 60) {
            float min = time % 60f;
            float second = time - (min * 60f);
            timeTextF.text = min.ToString("00") + "min" + second.ToString("00") + "sec";
        } else
            timeTextF.text = time.ToString("00") + "sec";
        timeTextS.text = timeTextF.text;
        timeTextT.text = timeTextF.text;
        rankTextF.text = "rank " + rank.ToString();
        rankTextS.text = rankTextF.text;
        rankTextT.text = rankTextF.text;
    }
}
