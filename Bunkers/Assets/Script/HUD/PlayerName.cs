using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    [SerializeField] private Text   nameTextF;
    [SerializeField] private Text   nameTextS;
    [SerializeField] private Text   nameTextT;

    private void Start() {
        nameTextF.text = GameObject.Find("GameHandler").GetComponent<GameHandler>().playerName;
        nameTextS.text = nameTextF.text;
        nameTextT.text = nameTextF.text;
    }
}
