using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {
    private void Awake() {
        PlayerPrefs.SetString("PlayerName", "Player#" + Random.Range(1000, 9999));
    }
}
