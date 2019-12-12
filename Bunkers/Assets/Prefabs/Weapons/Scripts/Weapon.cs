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

    private void Start() {
        loot.SetActive(true);
        equiped.SetActive(false);
    }

    public SpriteRenderer equip() {
        Debug.Log("EQUIPED");
        equiped.SetActive(true);
        return loot.GetComponent<SpriteRenderer>();
    }

    public void unequip() {
        Debug.Log("UNEQUIPED");
        equiped.SetActive(false);
    }

    public void getLoot(GameObject parent) {
        transform.parent = parent.transform;
        transform.localPosition = Vector3.zero;
        transform.rotation = parent.transform.rotation;
        loot.SetActive(false);
        GetComponent<Collider2D>().enabled = false;
    }

    public void attack() {
        if (wt == WeaponType.cub)
            equiped.GetComponent<melee>().Updater();
        else
            equiped.GetComponent<range>().Updater();
    }

    public void drop() {
        equiped.SetActive(false);
        loot.SetActive(true);
        transform.parent = null;
        GetComponent<Collider2D>().enabled = true;
    }


}
