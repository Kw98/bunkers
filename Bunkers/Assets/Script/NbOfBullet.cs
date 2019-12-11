using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NbOfBullet : MonoBehaviour
{
    public PlayerAction player;
    private Text text;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        if (player.inventory.weapons[0] != null)
        {
            if (player.inventory.weapons[player.inventory.actualEquiped].transform.Find("Equiped").gameObject.GetComponent<range>().chargers.Count > 0)
                text.text = player.inventory.weapons[player.inventory.actualEquiped].transform.Find("Equiped").gameObject.GetComponent<range>().chargers[0].gameObject.GetComponent<Charger>().actualNbOfBullets + "";
            else
                text.text = "0";
        }
    }
}
