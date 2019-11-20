using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public GameObject thePlayer;
    private Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = thePlayer.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDamage();
    }

    void UpdateDamage()
    {
        Slider.value = playerScript.currentHealth;
    }
}
