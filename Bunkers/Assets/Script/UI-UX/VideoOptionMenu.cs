using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoOptionMenu : MonoBehaviour
{
    [SerializeField] private Picker resolutionPicker;
    [SerializeField] private Picker screenModePicker;

    private void Start() {
        InitResolutions();
        InitScreenMode();
    }

    private void InitScreenMode() {
        string[] arr = {"FullScreen", "Window"};
        screenModePicker.SetPicker(arr, 0);
    }

    private void InitResolutions() {
        Resolution[] res = Screen.resolutions;
        List<string> resTxt = new List<string>();
        int current = 0;
        int i = 0;
        foreach (Resolution r in res) {
            if (r.width == Screen.currentResolution.width && r.height == Screen.currentResolution.height)
                current = i;
            resTxt.Add(r.width.ToString() + "x" + r.height.ToString());
            i++;
        }
        resolutionPicker.SetPicker(resTxt.ToArray(), current);
    }

    public void OnClick_Apply() {
        Resolution[] res = Screen.resolutions;
        int i = resolutionPicker.GetCurrent();
        if (screenModePicker.GetCurrent() == 0)
            Screen.SetResolution(res[i].width, res[i].height, FullScreenMode.FullScreenWindow);
        else
            Screen.SetResolution(res[i].width, res[i].height, FullScreenMode.Windowed);
    }
}
