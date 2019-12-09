using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRoomPrefabNetwork : MonoBehaviour
{
    [SerializeField] private Text   mainT;
    [SerializeField] private Text   secondT;
    [SerializeField] private Text   thirdT;

    public void InitName(string name) {
        mainT.text = name;
        secondT.text = name;
        thirdT.text = name;
    }
}
