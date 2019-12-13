using UnityEngine;

    public enum WeaponType {
        ak47,
        gun,
        silencegun,
        shotgun,
        uzi,
        m4,
        cub,
        unarmed
    }

public class Weapon : MonoBehaviour
{

    public WeaponType    wt;
    public GameObject  loot;
    public GameObject  equiped;
    public bool lootable;
    private bool activeUpdate;
    private float   nextTimeLootable;

    private void Update() {
        if (!activeUpdate)
            return;
        if (Time.time > nextTimeLootable)
            lootable = true;
    }

    private void Start() {
        loot.SetActive(true);
        equiped.SetActive(false);
        nextTimeLootable = 0;
        lootable = true;
        activeUpdate = false;
    }

    public SpriteRenderer equip() {
        equiped.SetActive(true);
        return loot.GetComponent<SpriteRenderer>();
    }

    public void unequip() {
        equiped.SetActive(false);
    }

    public void getLoot(GameObject parent) {
        transform.parent = parent.transform;
        transform.localPosition = Vector3.zero;
        transform.rotation = parent.transform.rotation;
        loot.SetActive(false);
        lootable = false;
        activeUpdate = false;
        GetComponent<Collider2D>().enabled = false;
    }

    public void attack() {
        if (wt == WeaponType.cub)
            equiped.GetComponent<melee>().Updater();
        else
            equiped.GetComponent<range>().Updater();
    }

    public void drop() {
        activeUpdate = true;
        nextTimeLootable = Time.time + 1f;
        equiped.SetActive(false);
        loot.SetActive(true);
        transform.parent = null;
        GetComponent<Collider2D>().enabled = true;
    }


}
