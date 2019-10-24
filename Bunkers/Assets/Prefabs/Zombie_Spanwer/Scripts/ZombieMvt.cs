using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMvt : MonoBehaviour
{ 
    public GameObject player;
    public float speed = 0;
    private Vector3 v_diff;
    private float atan2;

    void Update()
    {
        Chase();
    }

    void Chase()
    {
        Vector3 targetDirection = player.transform.position - transform.position;
        transform.position += targetDirection * speed * Time.deltaTime;
        v_diff = (player.transform.position - transform.position);
        atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
        transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
    }
}
