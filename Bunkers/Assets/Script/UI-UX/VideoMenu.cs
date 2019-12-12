using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoMenu : MonoBehaviour {
    [SerializeField] private Picker resPicker;
    private FullScreenMode  screenMode;
    private Resolution[]   resolutions;

    private void Awake() {
        resolutions = Screen.resolutions;
        int currentRes = 0;
        int i = 0;
        Resolution CurrentR = Screen.currentResolution;
        string[]    resArr = new string[resolutions.Length];
        foreach (Resolution r in resolutions) {
            resArr[i] = "" + r.width + "X" + r.height;
            if (r.ToString() == CurrentR.ToString())
                currentRes = i;
            i++;
        }
        resPicker.SetPicker(resArr, currentRes);
    }
}
