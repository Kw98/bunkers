using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct player_score_s {
    public GameObject  player;
    public int         score;
}

public class ScoreHandler : MonoBehaviour
{
    public int  pointDay;
    public int  pointHour;
    public int  pointMinute;
    public int  pointKill;
    public int  beginningPoints;

    [SerializeField] private ScoreUI    gameOver;
    [SerializeField] private ScoreUI    victory;
    [SerializeField] private ScoreUI    hud;

    private player_score_s[]    playersScore;
    private ligthHandle lightHandler;

    void Start() {
        gameOver.OnScoreChanged(beginningPoints.ToString());
        victory.OnScoreChanged(beginningPoints.ToString());
        hud.OnScoreChanged(beginningPoints.ToString("00000"));
        lightHandler = GameObject.Find("LightHandler").gameObject.GetComponent<ligthHandle>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        playersScore = new player_score_s[4];
        int i = 0;
        foreach (GameObject p in players) {
            player_score_s  ps;
            ps.player = p;
            ps.score = beginningPoints;
            playersScore[i] = ps;
            i++;
        }
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < playersScore.Length; i++) {
            if (!playersScore[i].player)
                continue;
            playersScore[i].score = beginningPoints - (lightHandler.dayCounter * pointDay) - ((int)lightHandler.hours * pointHour) - ((int)lightHandler.minutes * pointMinute);
            if (playersScore[i].score < 0)
                playersScore[i].score = 0;
            gameOver.OnScoreChanged(playersScore[i].score.ToString());
            victory.OnScoreChanged(playersScore[i].score.ToString());
            hud.OnScoreChanged(playersScore[i].score.ToString("00000"));
        }
    }
}
