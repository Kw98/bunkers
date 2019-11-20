using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {
    [SerializeField] private GameObject GameMenuObj;
    [SerializeField] private GameObject OptionMenuObj;
    [SerializeField] private GameObject GameOverMenuObj;
    [SerializeField] private GameObject VictoryMenuObj;

    private void Update() {
        if (VictoryMenuObj.active)
        {
            Time.timeScale = 0;
            return;
        }
        Time.timeScale = 1;
        if (GameOverMenuObj.active)
            return;
        if (Input.GetKeyDown(KeyCode.Escape) && !OptionMenuObj.active) {
            if (GameMenuObj.active)
                GameMenuObj.SetActive(false);
            else
                GameMenuObj.SetActive(true);
        }
    }

    public void     OnGameMenuPressed() {
        if (GameOverMenuObj.active || OptionMenuObj.active || VictoryMenuObj.active)
            return;
        if (GameMenuObj.active)
            GameMenuObj.SetActive(false);
        else
            GameMenuObj.SetActive(true);
    }

    public void    OnMenuPressed() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void    OnOptionsPressed() {
        GameMenuObj.SetActive(false);
        OptionMenuObj.SetActive(true);
    }

    public void    OnExitPressed() {
        Application.Quit();
    }

    public void     OnRetry() {
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }
}
