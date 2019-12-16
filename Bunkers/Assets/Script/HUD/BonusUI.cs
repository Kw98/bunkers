using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusUI : MonoBehaviour
{
    [SerializeField] private Image ammoCoverUI;
    [SerializeField] private Text ammoTxt;
    [SerializeField] private Image speedCoverUI;
    [SerializeField] private Text speedTxt;
    [SerializeField] private Image damageCoverUI;
    [SerializeField] private Text damageTxt;
    [SerializeField] private Bonus   ammo;
    [SerializeField] private Bonus   speed;
    [SerializeField] private Bonus   damage;

    void Start() {
        ammoTxt.gameObject.SetActive(false);
        speedTxt.gameObject.SetActive(false);
        damageTxt.gameObject.SetActive(false);
        ammoCoverUI.gameObject.SetActive(true);
        speedCoverUI.gameObject.SetActive(true);
        damageCoverUI.gameObject.SetActive(true);
    }

    void Update()
    {
        if (ammo.activated == true) {
            ammoTxt.gameObject.SetActive(true);
            ammoCoverUI.gameObject.SetActive(false);
            SetText(ammoTxt, ammo.time);
        } else {
            ammoTxt.gameObject.SetActive(false);
            ammoCoverUI.gameObject.SetActive(true);
        }
        if (speed.activated == true) {
            speedTxt.gameObject.SetActive(true);
            speedCoverUI.gameObject.SetActive(false);
            SetText(speedTxt, speed.time);
        } else {
            speedTxt.gameObject.SetActive(false);
            speedCoverUI.gameObject.SetActive(true);
        }
        if (damage.activated == true) {
            damageTxt.gameObject.SetActive(true);
            damageCoverUI.gameObject.SetActive(false);
            SetText(damageTxt, damage.time);
        } else {
            damageTxt.gameObject.SetActive(false);
            damageCoverUI.gameObject.SetActive(true);
        }
    }

    private void SetText(Text t, float time) {
        float min = Mathf.Floor(time / 60f);
        float sec = time % 60f;
        t.text = min.ToString("00") + ":" + sec.ToString("00");
    }
}
