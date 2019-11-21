using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Text mainText;
    [SerializeField] private Text secondText;
    [SerializeField] private Text thirdText;

    public void    OnScoreChanged(string text) {
        mainText.text = text;
        secondText.text = text;
        thirdText.text = text;
    }
}
