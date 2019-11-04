using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMvt : MonoBehaviour
{ 
    public GameObject player;
    public float speed = 0;
    private Vector3 v_diff;
    private float atan2;
    private float distance;
    private Animator animation;
    private bool dead = false;


    void Awake()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        print(distance);

        if (Input.GetKeyDown("space"))
        {
            animation.SetBool("isDead", true);
            dead = true;
        }
        else if  (distance < 0.23)
        {
            var rand = Random.Range(1, 3);
            if (rand == 1)
            {
                animation.SetBool("isAttacking", true);
                animation.SetBool("isAttacking2", false);
            }
            else
            {
                animation.SetBool("isAttacking2", true);
                animation.SetBool("isAttacking", false);
            }
        }
        else
        {
            animation.SetBool("isAttacking", false);
            animation.SetBool("isAttacking2", false);
            Chase();
        }
    }

    void Chase()
    {
        Vector3 targetDirection = player.transform.position - transform.position;
        if (dead != true)
        {
            transform.position += targetDirection * speed * Time.deltaTime;
            v_diff = (player.transform.position - transform.position);
            atan2 = Mathf.Atan2(v_diff.y, v_diff.x);

            transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
        }
    }


}
