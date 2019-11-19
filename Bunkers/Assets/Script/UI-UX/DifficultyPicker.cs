using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyPicker : MonoBehaviour {
    [SerializeField] private Text   MainDifficultyText;
    [SerializeField] private Text   SecondDifficultyText;
    [SerializeField] private Text   ThirdDifficultyText;
    private int ActualDifficulty = 0;
    private string[]  Difficulties = {"easy", "medium", "hard"};

    void Start() {
        UpdateDifficultyText();
    }

    public void switchDifficultyLeft() {
        ActualDifficulty--;
        if (ActualDifficulty < 0)
            ActualDifficulty = Difficulties.Length - 1;
        UpdateDifficultyText();
    }

    public void switchDifficultyRight() {
        ActualDifficulty++;
        if (ActualDifficulty >= Difficulties.Length)
            ActualDifficulty = 0;
        UpdateDifficultyText();
    }

    private void    UpdateDifficultyText() {
        MainDifficultyText.text = Difficulties[ActualDifficulty];
        SecondDifficultyText.text = Difficulties[ActualDifficulty];
        ThirdDifficultyText.text = Difficulties[ActualDifficulty];
    }
}
