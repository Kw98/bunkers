using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum sound_type_e {
    MUSIC,
    EFFECT
};

public class SoundVolumeHandler : MonoBehaviour
{
    public sound_type_e soundType;
    [SerializeField] private AudioSource    source;
    // Start is called before the first frame update
    void Start() {
        source = GetComponent<AudioSource>();
        if (soundType == sound_type_e.MUSIC)
            source.volume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        else if (soundType == sound_type_e.EFFECT)
            source.volume = PlayerPrefs.GetFloat("SoundEffectVolume", 1.0f);
    }

    // Update is called once per frame
    void Update() {
        if (soundType == sound_type_e.MUSIC)
            source.volume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        else if (soundType == sound_type_e.EFFECT)
            source.volume = PlayerPrefs.GetFloat("SoundEffectVolume", 1.0f);
    }
}
