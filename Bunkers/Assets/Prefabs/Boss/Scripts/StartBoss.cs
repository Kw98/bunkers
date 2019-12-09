using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<BossMvmt>().enabled = true;
        }
    }
}
