using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMvt : MonoBehaviour
{ 
    public GameObject player;
    public float speed = 0;
    private Vector3 v_diff;
    private float atan2;
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player Position: X = " + player.transform.position.x + " --- Y = " + player.transform.position.y + " --- Z = " +
        player.transform.position.z);
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
