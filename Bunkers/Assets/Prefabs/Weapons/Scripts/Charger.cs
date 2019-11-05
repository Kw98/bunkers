using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{
    public int  maxBullets;
    public int  actualNbOfBullets;
    public WeaponType   weaponType;

    // Update is called once per frame
    private void Start() {
        actualNbOfBullets = maxBullets;
    }

    public bool   useBullet() {
        if (actualNbOfBullets <= 0)
            return false;
        actualNbOfBullets--;
        return true;
    }
}