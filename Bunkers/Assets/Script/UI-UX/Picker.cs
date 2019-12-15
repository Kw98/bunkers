using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picker : MonoBehaviour
{
    [SerializeField] private Text   pickerTM;
    [SerializeField] private Text   pickerTS;
    private int  current;
    private string[]  textP = { "NONE" };

    void Start() {
        current = 0;
    }

    public int  GetCurrent() { return current; }

    public void SetPicker(string[] t, int index) {
        textP = t;
        current = index;
        if (current >= textP.Length)
            current = 0;
        UpdateText();
    }

    private void UpdateText() {
        pickerTM.text = textP[current];
        pickerTS.text = pickerTM.text;
    }

    public void    OnClick_LeftArrow() {
        current--;
        if (current < 0)
            current = textP.Length - 1;
        UpdateText();
    }

    public void    OnClick_RightArrow() {
        current++;
        if (current >= textP.Length)
            current = 0;
        UpdateText();
    }
}
