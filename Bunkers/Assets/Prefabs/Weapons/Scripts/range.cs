using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range : MonoBehaviour
{
    public int  damage;
    public float    reloadTime;
    public float       fireRate;
    public Transform   firePoint;
    public GameObject   bulletPrefab;
    public int  maxCharger;
    public List<GameObject>   chargers;
    private bool    isFiring;
    private float      fireTime;

    // Start is called before the first frame update
    void Start()
    {
        isFiring = false;
        fireTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            isFiring = true;
        if (Input.GetMouseButtonUp(0))
            isFiring = false;
        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(reload());
    }

    private void FixedUpdate() {
        if (isFiring) {
            fireTime -= Time.deltaTime;
            if (fireTime <= 0) {
                fireTime = fireRate;
                shoot();
            }
        } else
            fireTime = 0;
    }

    private void    shoot() {
        // Debug.Log(chargers.Count);
        if (chargers.Count > 0 && chargers[0].GetComponent<Charger>().useBullet()) {
            GameObject b = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            b.GetComponent<Bullet>().damages = damage;
        }
    }

    private IEnumerator reload() {
        yield return new WaitForSeconds(reloadTime);
        Debug.Log("reloading");
        if (chargers.Count > 0) {
            GameObject  c = chargers[0];
            chargers.RemoveAt(0);
            if (c.GetComponent<Charger>().actualNbOfBullets <= 0) {
                Destroy(c);
            } else if (chargers.Count > 1 && c.GetComponent<Charger>().actualNbOfBullets > 0)
                chargers.Add(c);
        }
        Debug.Log("reloaded");
    }
}
