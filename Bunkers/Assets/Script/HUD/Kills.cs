using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kills : MonoBehaviour
{
    [SerializeField] private Text   killsTextF;
    [SerializeField] private Text   killsTextS;
    [SerializeField] private Text   killsTextT;
    [SerializeField] private ScoreHandler   scoreHandler;

    void Start() {
        UpdateText(scoreHandler.kills);
    }

    void Update() {
        UpdateText(scoreHandler.kills);
    }

    private void UpdateText(int kills) {
        killsTextF.text = kills.ToString() + "kills";
        killsTextS.text = kills.ToString() + "kills";
        killsTextT.text = kills.ToString() + "kills";
    }
}
