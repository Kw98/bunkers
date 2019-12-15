using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] private Text   pointsTextF;
    [SerializeField] private Text   pointsTextS;
    [SerializeField] private Text   pointsTextT;
    [SerializeField] private ScoreHandler   scoreHandler;

    void Start() {
        UpdateText(scoreHandler.score.points);
    }

    void Update() {
        UpdateText(scoreHandler.score.points);
    }

    private void UpdateText(int points) {
        pointsTextF.text = points.ToString("00000") + "pts";
        pointsTextS.text = points.ToString("00000") + "pts";
        pointsTextT.text = points.ToString("00000") + "pts";
    }
}
