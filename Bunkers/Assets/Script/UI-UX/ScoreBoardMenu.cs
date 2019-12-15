using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoardMenu : MonoBehaviour
{
    [SerializeField] private GameObject viewerContent;
    [SerializeField] private GameObject scoreViewerPrefab;
    private bool    scoreboardMode;

    private void Start() {
        scoreboardMode = true;
    }

    private void OnEnable() {
        ScoreBoard(scoreboardMode);
    }

    private void ScoreBoard(bool points) {
        ScorePointsComparer spc = new ScorePointsComparer();
        ScoreTimeComparer stc = new ScoreTimeComparer();
        GameHandler gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        List<Score> scoreboard = new List<Score>(gameHandler.score.scoreList);
        foreach (Transform child in viewerContent.transform)
            Destroy(child.gameObject);
        if (points)
            scoreboard.Sort(spc);
        else
            scoreboard.Sort(stc);
        int rank = 1;
        foreach (Score score in scoreboard) {
            GameObject sv = Instantiate(scoreViewerPrefab);
            sv.GetComponent<ScoreViewer>().InitScoreViewer(score.playerName, score.points, score.day, score.hour, score.min, rank);
            sv.transform.SetParent(viewerContent.transform, false);
            rank++;
        }
    }

    public void OnClick_Points() {
        if (!scoreboardMode) {
            scoreboardMode = true;
            ScoreBoard(scoreboardMode);
        }
    }

    public void OnClick_Time() {
        if (scoreboardMode) {
            scoreboardMode = false;
            ScoreBoard(scoreboardMode);
        }
    }
}
