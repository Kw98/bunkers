using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    [SerializeField] private GameObject Player;

    void Update()
    {
        if (Player)
            Slider.value = Player.GetComponent<PlayerAction>().currentHealth;
    }
}
