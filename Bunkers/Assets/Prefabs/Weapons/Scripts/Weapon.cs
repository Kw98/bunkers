using UnityEngine;

    public enum WeaponType {
        ak47,
        gun,
        silencegun,
        shotgun,
        uzi,
        m4,
        cub
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

    private void FixedUpdate() {
    }

    private void OnCollisionEnter2D(Collision2D other) {
    }

    public SpriteRenderer equip() {
        Debug.Log("EQUIPED");
        equiped.active = true;
        return loot.GetComponent<SpriteRenderer>();
    }

    public void unequip() {
        Debug.Log("UNEQUIPED");
        equiped.active = false;
    }

    public void getLoot(GameObject parent) {
        transform.parent = parent.transform;
        transform.localPosition = Vector3.zero;
        transform.rotation = parent.transform.rotation;
        loot.active = false;
        GetComponent<Collider2D>().enabled = false;
    }

    public void drop() {
        equiped.active = false;
        loot.active = true;
        transform.parent = null;
        GetComponent<Collider2D>().enabled = true;
    }

}
