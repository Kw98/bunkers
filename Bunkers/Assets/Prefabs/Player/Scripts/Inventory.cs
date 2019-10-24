using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject>    chargers;
    private Weapon.WType[]    weapons;
    private int             maxWeapons = 3;
    private int             currentWeapons = 0;
    private int             medicKit;

    // Start is called before the first frame update
    void Start() {
        chargers = new List<GameObject>();
        weapons = new Weapon.WType[3] {
            Weapon.WType.none,
            Weapon.WType.none,
            Weapon.WType.none };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool loot(GameObject obj) {
        if (obj.tag == "Weapon") {
            Weapon.WType    wtype = obj.GetComponent<Weapon>().wType;
            if (currentWeapons < maxWeapons) {
                for (int i = 0; i < maxWeapons; i++) {
                    if (weapons[i] == Weapon.WType.none || weapons[i] == wtype) {
                        weapons[i] = wtype;
                        break;
                    }
                }
                currentWeapons++;
                return true;
            } else
                return false;
        }
        return true;
    }
}
