using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeOptionMenu : MonoBehaviour
{

    [SerializeField] private Slider MusicVolume;
    [SerializeField] private Slider SoundEffectVolume;

    void Start() {
        MusicVolume.value = PlayerPrefs.GetFloat("MusicVolume", MusicVolume.maxValue);
        SoundEffectVolume.value = PlayerPrefs.GetFloat("SoundEffectVolume", SoundEffectVolume.maxValue);
    }

    public void OnMusicVolume_Change() {
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume.value);
    }

    public void OnSoundEffectVolume_Change() {
        PlayerPrefs.SetFloat("SoundEffectVolume", SoundEffectVolume.value);
    }

}
