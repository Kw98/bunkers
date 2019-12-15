using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject    ddol;
    [SerializeField] private GameObject    FirstCoMenu;
    [SerializeField] private GameObject    MainMenu;

    void Start() {
        if (PlayerPrefs.GetInt("FirstCo", 0) == 1) {
            MainMenu.SetActive(true);
            if (GameObject.FindGameObjectWithTag("DDOL") == null)
                Instantiate(ddol);
        } else {
            FirstCoMenu.SetActive(true);
        }
    }

    public void OnClick_Exit() {
        Application.Quit();
    }
}
