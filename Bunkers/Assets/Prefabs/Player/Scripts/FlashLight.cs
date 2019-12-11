using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private ligthHandle lightHandler;
    private Light light;
    private bool lightActivated;
    public float timeBattery;
    public float nbMaxOfBattery;
    public float ActualNbOfBattery;
    public float timeActualBattery;
    public GameObject batterytext;

    private void Start() {
        timeActualBattery = timeBattery;
        lightActivated = true;
        lightHandler = GameObject.Find("LightHandler").GetComponent<ligthHandle>();
        light = GetComponent<Light>();
        light.intensity = 1.5f;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && ActualNbOfBattery > 0)
        {
            if (lightActivated)
            {
                light.intensity = 0;
                lightActivated = false;
            }
            else
            {
                light.intensity = 1.5f;
                lightActivated = true;
            }
        }
        if (ActualNbOfBattery > 0 && timeActualBattery > 0.0f && lightActivated)
        {
            timeActualBattery -= Time.deltaTime;
        }
        else if (ActualNbOfBattery > 0 && timeActualBattery <= 0.0f)
        {
            --ActualNbOfBattery;
            timeActualBattery = timeBattery;
        }
        if (ActualNbOfBattery == 0)
        {
            light.intensity = 0;
            lightActivated = false;
        }
        if (Input.anyKeyDown && batterytext.active)
            batterytext.active = false;
    }

    public void AddBattery(GameObject obj)
    {
        if ((ActualNbOfBattery + 1) > nbMaxOfBattery)
        {
            batterytext.active = true;
            return;
        }
        ++ActualNbOfBattery;
        if (ActualNbOfBattery == 1)
            timeActualBattery = timeBattery;
        Destroy(obj);
    }
}
