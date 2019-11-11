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
        this.GetComponent<Collider2D>().enabled = true;
    }

    // Update is called once per frame


    void  attack()
    {
        var rand = Random.Range(1, 3);
        if (rand == 1)
        {
            animation.SetBool("isAttacking2", false);
            animation.SetBool("isAttacking", true);
        }
        else
        {
            animation.SetBool("isAttacking", false);
            animation.SetBool("isAttacking2", true);
        }
    }

    void Iamdead()
    {
        var rand = Random.Range(1, 4);
        if (rand == 1)
            animation.SetBool("isDead", true);
        if (rand == 2)
            animation.SetBool("isDead2", true);
        if (rand == 3)
            animation.SetBool("isDead3", true);
        dead = true;
        transform.position = transform.localPosition;
    }


    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if  (distance < 0.20)
            attack();
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

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Bullet")
        {
            Destroy(hit.transform.gameObject);
            Iamdead();
            this.GetComponent<Collider2D>().enabled = false;
        }
    }



}
