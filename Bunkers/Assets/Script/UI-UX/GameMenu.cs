using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {
    [SerializeField] private GameObject GameMenuObj;
    [SerializeField] private GameObject OptionMenuObj;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !OptionMenuObj.active) {
            if (GameMenuObj.active)
                GameMenuObj.SetActive(false);
            else
                GameMenuObj.SetActive(true);
        }
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
}
