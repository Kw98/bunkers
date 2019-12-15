using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieMvt : MonoBehaviour
{
    private GameObject[] players;
    public float speed = 0;
    public bool dead = false;
    private Vector3 v_diff;
    private float atan2;
    private float distance;
    public float MaxHealth;
    public float CurrentHealth;
    private Animator animation;
    [SerializeField] private Slider  slider;
    [SerializeField] private GameObject healthbarUI;


    private void setZombieHp() {
        int day = GameObject.Find("HUD").GetComponent<ScoreHandler>().score.day;
        float scaling = 10f;
        if (PlayerPrefs.GetString("DIFFICULTY", "easy") == "easy")
            MaxHealth = 20f;
        else if (PlayerPrefs.GetString("DIFFICULTY") == "normal")
            MaxHealth = 30f;
        else if (PlayerPrefs.GetString("DIFFICULTY") == "hard") {
            MaxHealth = 50f;
            scaling = 20f;
            speed += 0.5f;
        } else if (PlayerPrefs.GetString("DIFFICULTY") == "hell") {
            MaxHealth = 70f;
            scaling = 40f;
            speed += 1f;
        }
        for (int i = 1; i < day; i++)
            MaxHealth += scaling;
    }

    void Awake()
    {
        setZombieHp();
        CurrentHealth = MaxHealth;
        slider.maxValue = MaxHealth;
        slider.value = CurrentHealth;
        animation = GetComponent<Animator>();
        this.GetComponent<Collider2D>().enabled = true;
        players = GameObject.FindGameObjectsWithTag("Player");
        healthbarUI.SetActive(false);
    }

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

    private void Dead()
    {
        var rand = Random.Range(1, 4);
        if (rand == 1)
            animation.SetBool("isDead", true);
        if (rand == 2)
            animation.SetBool("isDead2", true);
        if (rand == 3)
            animation.SetBool("isDead3", true);
        dead = true;
        healthbarUI.SetActive(false);
        GameObject.Find("HUD").GetComponent<ScoreHandler>().kills++;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Drop>().spawn();
    }

    private void Update() {
        if (CurrentHealth < MaxHealth && CurrentHealth > 0f) {
            healthbarUI.SetActive(true);
            slider.value = CurrentHealth;
        }
    }

  void FixedUpdate()
    {
        if (dead)
            return;
        if (CurrentHealth <= 0f) {
            Dead();
            return;
        }
        GameObject p = null;
        foreach (GameObject player in players) {
            p = player;
        }
        if (!p)
            return;
        distance = Vector2.Distance(transform.position, p.transform.position);
        if (distance < 0.20)
            attack();
        else {
            animation.SetBool("isAttacking", false);
            animation.SetBool("isAttacking2", false);
            Chase();
        }
    }

    void Chase()
    {
        GameObject p = null;
        foreach (GameObject player in players)
        {
             p = player;
        }
        distance = Vector2.Distance(transform.position, p.transform.position);
        Vector3 targetDirection = p.transform.position - transform.position;
        if (dead != true && distance < 2)
        {
            transform.position += targetDirection * speed * Time.deltaTime;
            v_diff = (p.transform.position - transform.position);
            atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
            transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Bullet") {
            CurrentHealth -= hit.gameObject.GetComponent<Bullet>().damages;
            if (CurrentHealth <= 0f) {
                Physics2D.IgnoreCollision(hit.collider, GetComponent<Collider2D>());
                Destroy(hit.transform.gameObject);
                Dead();
            }
        }
    }

}
