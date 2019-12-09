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

    void Awake()
    {
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
        if (hit.gameObject.tag == "Bullet" && !red)
        {
            red = true;
            timeShoot = time;
            renderer.color = new Color(255f, 0f, 0f, 1f);
            CurrentHealth -= 20.0f /*hit.gameObject.GetComponent<Bullet>().Damages*/;
            Destroy(hit.transform.gameObject);
        }
    }
}
