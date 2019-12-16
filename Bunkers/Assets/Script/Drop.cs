using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private GameObject[]   chargers;
    [SerializeField] private GameObject     medikit;
    [SerializeField] private GameObject[]     bonuses;
    [SerializeField] private int[]  chances;
    private int ammoDropRate;
    private int medicDropRate;

    private void Start() {
        if (PlayerPrefs.GetString("DIFFICULTY", "easy") == "easy") {
            ammoDropRate = 70;
            medicDropRate = 70;
        } else if (PlayerPrefs.GetString("DIFFICULTY") == "normal") {
            ammoDropRate = 50;
            medicDropRate = 50;
        } else if (PlayerPrefs.GetString("DIFFICULTY") == "hard") {
            ammoDropRate = 40;
            medicDropRate = 40;
        } else if (PlayerPrefs.GetString("DIFFICULTY") == "hell") {
            ammoDropRate = 35;
            medicDropRate = 35;
        }
    }

    public void spawn() {
        int r = Random.Range(0, 100);
        int c = Random.Range(0, 10);
        if (c <= 4) {
            if (r <= ammoDropRate)
                DropAmmo();
        } else if (c <= 7) {
            if (r <= medicDropRate)
                DropMedikit();
        } else {
            DropBonus();
        }
    }

    private void DropBonus() {
        int bonus = Random.Range(0, bonuses.Length);
        int luck = Random.Range(0, chances[bonus]);
        if (luck >= Random.Range(0, 101)) {
            GameObject obj = bonuses[bonus];
            float rand = Random.Range(-0.2f, 0.2f);
            float rand2 = Random.Range(-0.2f, 0.2f);
            obj.transform.position = new Vector3(transform.position.x + rand, transform.position.y + rand2, 0.0f);
            Instantiate(obj);
        }
    }

    private void DropAmmo() {
        GameObject ammo = chargers[Random.Range(0, chargers.Length)];
        float rand = Random.Range(-0.2f, 0.2f);
        float rand2 = Random.Range(-0.2f, 0.2f);
        ammo.transform.position = new Vector3(transform.position.x + rand, transform.position.y + rand2, 0.0f);
        Instantiate(ammo);
    }

    private void DropMedikit() {
        float rand = Random.Range(-0.2f, 0.2f);
        float rand2 = Random.Range(-0.2f, 0.2f);
        medikit.transform.position = new Vector3(transform.position.x + rand, transform.position.y + rand2, 0.0f);
        Instantiate(medikit);
    }
}
