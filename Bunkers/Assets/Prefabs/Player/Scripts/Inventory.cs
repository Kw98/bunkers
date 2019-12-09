using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//change weapon array to list
public class Inventory : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject   melee;
    public int  selectedWeapon;
    private int currentNbWeapons;
    public int actualEquiped;
    private PhotonView  photonView;

    private void Start() {
        photonView = GetComponent<PhotonView>();
        currentNbWeapons = 0;
    }

    private void Update() {
        if (!photonView.isMine)
            return;
        // actualEquiped = selectedWeapon;
        // if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
        //     selectedWeapon = (selectedWeapon + 1) % weapons.Length;
        //     equip();
        // } else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
        //     selectedWeapon = Mathf.Abs(selectedWeapon - 1) % weapons.Length;
        //     equip();
        // } if (Input.GetKeyDown(KeyCode.Alpha1) && selectedWeapon != 0) {
        //     selectedWeapon = 0;
        //     equip();
        // } if (Input.GetKeyDown(KeyCode.Alpha2) && selectedWeapon != 1) {
        //     selectedWeapon = 1;
        //     equip();
        // } if (Input.GetKeyDown(KeyCode.Alpha3) && selectedWeapon != 2) {
        //     selectedWeapon = 2;
        //     equip();
        // } if (Input.GetKeyDown(KeyCode.F) && selectedWeapon != -1) {
        //     selectedWeapon = -1;
        //     equip();
        // }
    }

    public bool loot(GameObject obj) {
        if (obj.tag == "Weapon") {
            WeaponType wt = obj.GetComponent<Weapon>().wt;
            if (currentNbWeapons < weapons.Length) {
                for (int i = 0; i < weapons.Length; i++) {
                    if (weapons[i] == null) {
                        weapons[i] = obj;
                        weapons[i].GetComponent<Weapon>().getLoot(gameObject);
                        if (currentNbWeapons == 0) {
                            currentNbWeapons++;
                            selectedWeapon = i;
                            equip();
                        } else
                            weapons[i].GetComponent<Weapon>().unequip();
                        return true;
                    } else if (weapons[i].GetComponent<Weapon>().wt == wt) {
                        // get charger from weapon
                        Destroy(obj);
                        return true;
                    }
                }
            }
        } else if (obj.tag == "Charger") {
            WeaponType wt = obj.GetComponent<Charger>().weaponType;
            for (int i = 0; i < weapons.Length; i++) {
                if (weapons[i] && weapons[i].GetComponent<Weapon>().wt == wt) {
                    GameObject e = weapons[i].transform.Find("Equiped").gameObject;
                    range wp = e.GetComponent<range>();
                    if (wp.chargers.Count < wp.maxCharger) {
                        wp.chargers.Add(obj);
                        obj.transform.parent = e.transform;
                        obj.GetComponent<Collider2D>().enabled = false;
                        obj.GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
            }
        }
        return false;
    }

    public void drop() {
        if (selectedWeapon == -1)
            return;
        if (weapons[selectedWeapon]) {
            weapons[selectedWeapon].GetComponent<Weapon>().drop();
            weapons[selectedWeapon] = null;
            currentNbWeapons--;
            selectedWeapon--;
            if (selectedWeapon != -1)
                weapons[selectedWeapon].GetComponent<Weapon>().equip();
            else
                melee.SetActive(true);
        }
    }

    private void    equip() {
        if (actualEquiped != -1 && selectedWeapon == -1) {
            weapons[actualEquiped].GetComponent<Weapon>().unequip();
            melee.SetActive(true);
            return;
        } else if (actualEquiped == -1 && selectedWeapon != -1) {
            melee.SetActive(false);
            weapons[selectedWeapon].GetComponent<Weapon>().equip();
            return;
        }
        if (weapons[selectedWeapon] == null)
            return;
        weapons[actualEquiped].GetComponent<Weapon>().unequip();
        weapons[selectedWeapon].GetComponent<Weapon>().equip();
    }

}
