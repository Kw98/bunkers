using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private int    pointsDay;
    [SerializeField] private int    pointsHour;
    [SerializeField] private int    pointsMinute;
    [SerializeField] private int    pointsKill;
    [SerializeField] private int    startingPoints;
    [SerializeField] private GameObject player;
    [SerializeField] private ligthHandle    lightHandler;
    public Score    score;
    public int  kills;
    private GameHandler gameHandler;

    private void Start() {
        gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        score = new Score(gameHandler.playerName, startingPoints, lightHandler.dayCounter, lightHandler.hours, lightHandler.minutes);
        score.day = 1;
        kills = 0;
    }

    private void Update() {
        if (!player)
            return;
        score.points = startingPoints - (score.day * pointsDay) - ((int)score.hour * pointsHour) - ((int)score.min * pointsMinute) + (kills * pointsKill);
        if (score.points < 0)
            score.points = 0;
    }

    public void UpdateDay(int day) {
        score.day++;
    }

    public void UpdateHoursMinutes(float hours, float minutes) {
        score.hour = hours;
        score.min = minutes;
    }
}
