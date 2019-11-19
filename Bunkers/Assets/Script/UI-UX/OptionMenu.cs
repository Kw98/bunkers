using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private Slider MusicVolume;
    [SerializeField] private Slider SoundEffectVolume;

    private void OnGUI() {
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume.value);
        PlayerPrefs.SetFloat("SoundEffectVolume", SoundEffectVolume.value);
    }
}
