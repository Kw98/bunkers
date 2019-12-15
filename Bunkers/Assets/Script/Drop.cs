using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private GameObject[]   chargers;
    [SerializeField] private GameObject     medikit;
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
        if (Random.Range(0, 2) == 0) {
            if (r <= ammoDropRate)
                DropAmmo();
        } else {
            if (r <= medicDropRate)
                DropMedikit();
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
