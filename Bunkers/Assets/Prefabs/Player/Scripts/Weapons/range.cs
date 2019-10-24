using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range : MonoBehaviour
{
    private float      fireTime;
    public int         currentBulletNbr;
    public float       fireRate;
    public Transform   firePoint;
    public Animator    animator;
    public GameObject  bullet;

    // Start is called before the first frame update
    void Start()
    {
        fireTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
                reload();
        if (fireTime <= 0) {
            if (Input.GetMouseButtonDown(0) && currentBulletNbr > 0) {
                shoot();
                fireTime = fireRate;
            }
        } else
            fireTime -= Time.deltaTime;
    }


    private void    shoot() {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        currentBulletNbr -= 1;
    }

    private void    reload() {

    }
}
