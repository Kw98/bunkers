using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDHandler : MonoBehaviour
{
    [SerializeField] private GameObject HUDObj;
    [SerializeField] private GameObject OptionHUDObj;
    [SerializeField] private GameObject GameOverHUDObj;
    [SerializeField] private GameObject VictoryHUDObj;
    public GameObject ReloadTxt;
    public GameObject ReloadedTxt;
    private bool inMenu;

    private void Start() {
        inMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inMenu && Input.GetKeyDown(KeyCode.Escape) && !VictoryHUDObj.activeInHierarchy && !GameOverHUDObj.activeInHierarchy) {
            PauseGame();
            HUDObj.SetActive(true);
            inMenu = true;
        } else if (inMenu && Input.GetKeyDown(KeyCode.Escape)) {
            ContinueGame();
            HUDObj.SetActive(false);
            inMenu = false;
        }
    }

    public void OnVictory() {
        PauseGame();
        VictoryHUDObj.SetActive(true);
        GameHandler gameHandler = GameObject.Find("GameHandler").GetComponent<GameHandler>();
        ScoreHandler sh = GameObject.Find("HUD").GetComponent<ScoreHandler>();
        gameHandler.OnNewScore(sh.score.points, sh.score.day, sh.score.hour, sh.score.min);
    }

    public void OnGameOver() {
        PauseGame();
        GameOverHUDObj.SetActive(true);
    }

    public void OnClick_Continue() {
        HUDObj.SetActive(false);
        ContinueGame();
    }

    public void OnClick_Menu() {
        ContinueGame();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void OnClick_Quit() {
        ContinueGame();
        Application.Quit();
    }

    public void OnClick_Retry() {
        ContinueGame();
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }

    private void ContinueGame() {
        Time.timeScale = 1;
    }

    private void PauseGame() {
        Time.timeScale = 0;
    }
}
