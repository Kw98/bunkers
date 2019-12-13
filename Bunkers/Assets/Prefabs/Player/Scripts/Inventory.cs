using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//change weapon array to list
public class Inventory : MonoBehaviour {
    [SerializeField] private GameObject MeleeGo;
    [SerializeField] private int    MaxWeapon;
    [SerializeField] private GameObject CurrentWeaponSprite;
    [SerializeField] private List<GameObject>   Weapons;
    private int Current;

    private void Start() {
        MaxWeapon++;
        Weapons = new List<GameObject>();
        Weapons.Add(MeleeGo);
        Current = 0;
        CurrentWeaponSprite.SetActive(false);
    }

    private void Update() {
        int next = Current;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
            next = (next + 1) % Weapons.Count;
        else if (scroll < 0f)
            next = Mathf.Abs(next - 1) % Weapons.Count;
        else if (Input.GetKeyDown(KeyCode.Alpha1))
            next = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            next = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            next = 3;
        else if (Input.GetKeyDown(KeyCode.V))
            next = 0;
        if (next != Current && next < Weapons.Count)
            SwapWeapon(next);
    }

    public void Loot(GameObject obj) {
        if (obj.tag == "Weapon")
            LootWeapon(obj);
        else if (obj.tag == "Charger")
            LootAmmo(obj);
    }

    public void Attack() {
        if (Current == 0)
            Weapons[Current].GetComponent<melee>().Updater();
        else
            Weapons[Current].GetComponent<Weapon>().attack();
    }

    private void LootWeapon(GameObject obj) {
        Weapon weapon = obj.GetComponent<Weapon>();
        if (Weapons.Count + 1 >= MaxWeapon)
            return;
        for (int i = 1; i < Weapons.Count; i++) {
            if (weapon.wt == Weapons[i].GetComponent<Weapon>().wt) {
                // Loot Ammo
                return;
            }
        }
        weapon.getLoot(gameObject);
        Weapons.Add(obj);
        if (Current == 0)
            SwapWeapon(Weapons.Count - 1);
    }

    private void LootAmmo(GameObject obj) {
        Charger ammo = obj.GetComponent<Charger>();
        for (int i = 1; i < Weapons.Count; i++) {
            print(i);
            if (Weapons[i].GetComponent<Weapon>().wt == ammo.weaponType) {
                GameObject equiped = Weapons[i].transform.Find("Equiped").gameObject;
                range r = equiped.GetComponent<range>();
                if (r.chargers.Count < r.maxCharger) {
                    r.chargers.Add(obj);
                    obj.transform.SetParent(equiped.transform);
                    obj.transform.GetChild(0).gameObject.SetActive(false);
                    obj.GetComponent<Collider2D>().enabled = false;
                    obj.GetComponent<SpriteRenderer>().enabled = false;
                }
                return;
            }
        }
    }

    private void SwapWeapon(int next) {
        SpriteRenderer spriteRenderer = null;
        if (next == 0) {
            CurrentWeaponSprite.SetActive(false);
            Weapons[Current].GetComponent<Weapon>().unequip();
            Current = next;
            Weapons[Current].SetActive(true);
        } else if (Current == 0) {
            Weapons[Current].SetActive(false);
            Current = next;
            spriteRenderer =  Weapons[Current].GetComponent<Weapon>().equip();
            CurrentWeaponSprite.GetComponent<Image>().sprite = spriteRenderer.sprite;
        } else {
            Weapons[Current].GetComponent<Weapon>().unequip();
            Current = next;
            spriteRenderer = Weapons[Current].GetComponent<Weapon>().equip();
            CurrentWeaponSprite.GetComponent<Image>().sprite = spriteRenderer.sprite;
        }
    }

}
