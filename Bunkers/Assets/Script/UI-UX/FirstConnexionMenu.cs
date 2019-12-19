using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstConnexionMenu : MonoBehaviour
{
    [SerializeField] private Text   input;
    [SerializeField] private GameObject ddol;
    [SerializeField] private Text   inputS;
    [SerializeField] private Text   inputT;

    public void OnClick_Begin() {
        if (input.text.Length < 3)
            return;
        PlayerPrefs.SetInt("Id", Random.Range(1000, 9999));
        PlayerPrefs.SetString("PlayerName", input.text);
        PlayerPrefs.SetInt("FirstCo", 1);
        Instantiate(ddol);
    }

    public void OnText_Changed(InputField t) {
        inputS.text = t.text;
        inputT.text = t.text;
    }
}
