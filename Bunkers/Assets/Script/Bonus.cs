using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Bonus_Type {
    nuke,
    damage,
    speed,
    infinitAmmo
}

public class Bonus : MonoBehaviour
{
    public Bonus_Type   bt;
    public float time;
    public bool activated;

    private void Start() {
        activated = false;
        time = 15f;
    }

    private void Update() {
        if (activated == true && time <= 0f) {
            activated = false;
            time = 0f;
        }
        if (activated == true) {
            time -= Time.deltaTime;
        }
    }
}
