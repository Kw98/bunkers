using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBattery : MonoBehaviour
{
    public Text text;
    public GameObject slider;
    public FlashLight light;

    void Update()
    {
        text.text = light.ActualNbOfBattery + " / " + light.nbMaxOfBattery;
            slider.transform.localScale = new Vector3(light.timeActualBattery / light.timeBattery, 1f);
    }
}
