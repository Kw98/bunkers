using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;
    public BossHealthBar HealthBarBoss;
    public float Damages;
    private SpriteRenderer renderer;
    private float timeShoot;
    private bool red;
    private float time;

    private void setBossHp() {
        if (PlayerPrefs.GetString("DIFFICULTY", "easy") == "easy")
            MaxHealth = 100f;
        else if (PlayerPrefs.GetString("DIFFICULTY") == "normal") {
            MaxHealth = 150f;
            Damages = 2f;
        } else if (PlayerPrefs.GetString("DIFFICULTY") == "hard") {
            MaxHealth = 250f;
            Damages = 4f;
        } else if (PlayerPrefs.GetString("DIFFICULTY") == "hell") {
            MaxHealth = 300f;
            Damages = 6f;
        }
        CurrentHealth = MaxHealth;
    }

    void Awake()
    {
        setBossHp();
        red = false;
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        if (time - timeShoot > 0.5 && red)
        {
            red = false;
            renderer.color = new Color(255f, 255f, 255f, 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Bullet")
        {
            red = true;
            timeShoot = time;
            renderer.color = new Color(255f, 0f, 0f, 1f);
            CurrentHealth -= hit.gameObject.GetComponent<Bullet>().damages;
            Destroy(hit.transform.gameObject);
        }
    }
}
