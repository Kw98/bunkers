using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject Player;

    private void Start() {
        if (Player) {
            slider.value = Player.GetComponent<PlayerAction>().maxHealth;
            slider.maxValue = Player.GetComponent<PlayerAction>().maxHealth;
        }
    }

    private void Update()
    {
        if (Player)
            slider.value = Player.GetComponent<PlayerAction>().currentHealth;
    }
}
