using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private ligthHandle lightHandler;
    private Light light;

    private void Awake() {
        lightHandler = GameObject.Find("LightHandler").GetComponent<ligthHandle>();
        light = GetComponent<Light>();
    }

    void Update() {
        float time = (int)lightHandler.timer / 60;
        if (time >= 7 && time <= 20)
            light.intensity = 0;
        else
            light.intensity = 1.5f;
    }
}
