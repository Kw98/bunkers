using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picker : MonoBehaviour
{
    [SerializeField] private Text   MainT;
    [SerializeField] private Text   SecondT;
    [SerializeField] private Text   ThirdT;
    private int ActualChoice = 0;
    [SerializeField] private string[]  Choices;

    void Start() {
        UpdateChoice();
    }

    public void OnClick_ChoiceMinus() {
        ActualChoice--;
        if (ActualChoice < 0)
            ActualChoice = Choices.Length - 1;
        UpdateChoice();
    }

    public void OnClick_ChoicePlus() {
        ActualChoice++;
        if (ActualChoice >= Choices.Length)
            ActualChoice = 0;
        UpdateChoice();
    }

    private void    UpdateChoice() {
        MainT.text = Choices[ActualChoice];
        SecondT.text = Choices[ActualChoice];
        ThirdT.text = Choices[ActualChoice];
    }
}
