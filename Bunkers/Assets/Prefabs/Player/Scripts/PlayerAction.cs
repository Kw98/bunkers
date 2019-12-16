using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float    speed;
    public Rigidbody2D  rigidbody;
    public Camera   camera;
    public Animator legs;
    public Inventory inventory;
    public GameObject Light;
    private Vector2     movement;
    private Vector2         mousePos;
    private int             colNB;
    public Bonus    speedB;
    public Bonus    ammoB;
    public Bonus    damageB;

    private void Start() {
        colNB = 0;
        speedB.activated = false;
        speedB.bt = Bonus_Type.speed;
        speedB.time = 0f;
        ammoB.activated = false;
        ammoB.bt = Bonus_Type.infinitAmmo;
        ammoB.time = 0f;
        damageB.activated = false;
        damageB.bt = Bonus_Type.damage;
        damageB.time = 0f;
    }

    private void Update() {
        if (currentHealth <= 0) {
            Destroy(gameObject);
            return;
        }
        if (Input.GetKeyDown(KeyCode.A))
             gameObject.GetComponent<Inventory>().Drop();
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        legs.SetFloat("Run", movement.x + movement.y);
        inventory.Attack();
    }


    private void FixedUpdate() {
        if (colNB == 0)
            rigidbody.angularVelocity = 0;
        if (!speedB.activated)
            rigidbody.velocity = movement * speed;
        else
            rigidbody.velocity = movement * (speed + 0.5f);
        Vector2 lookDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rigidbody.rotation = angle;
        colNB = 0;
    }

    private void OnCollisionEnter2D(Collision2D hit) {
        if (hit.gameObject.tag == "Zombie") {
            currentHealth -= 1.0f;
            colNB++;
        }
        if (hit.gameObject.tag == "Boss") {
            currentHealth -= hit.gameObject.GetComponent<Boss>().Damages;
            colNB++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Weapon" || other.gameObject.tag == "Charger")
            gameObject.GetComponent<Inventory>().Loot(other.gameObject);
        else if (other.gameObject.tag == "Battery")
            Light.GetComponent<FlashLight>().AddBattery(other.gameObject);
        else if (other.gameObject.tag == "MedicPack" && currentHealth < maxHealth)
        {
            if (currentHealth + other.gameObject.GetComponent<MedicPack>().health > maxHealth)
                currentHealth = maxHealth;
            else
                currentHealth += other.gameObject.GetComponent<MedicPack>().health;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Victory")
            GameObject.Find("HUD").GetComponent<HUDHandler>().OnVictory();
        else if (other.gameObject.tag == "Bonus")
            LootBonus(other.gameObject);
    }

    private void LootBonus(GameObject bonus) {
        Bonus b = bonus.GetComponent<Bonus>();
        if (b.bt == Bonus_Type.damage) {
            damageB.time += b.time;
            damageB.activated = true;
        } else if (b.bt == Bonus_Type.infinitAmmo) {
            ammoB.time += b.time;
            ammoB.activated = true;
        } else if (b.bt == Bonus_Type.speed) {
            speedB.time += b.time;
            speedB.activated = true;
        } else if (b.bt == Bonus_Type.nuke) {
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
            foreach (GameObject z in zombies)
                z.GetComponent<ZombieMvt>().CurrentHealth = 0f;
        }
        Destroy(bonus);
    }

    private void OnDestroy() {
        if (GameObject.Find("HUD") != null)
            GameObject.Find("HUD").GetComponent<HUDHandler>().OnGameOver();
    }
}