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

    private void Start() {
        colNB = 0;
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
        rigidbody.velocity = movement;
        Vector2 lookDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rigidbody.rotation = angle;
        colNB = 0;
    }

    private void OnCollisionEnter2D(Collision2D hit) {
        //Debug.Log("COLLISION: " + hit.gameObject.tag);
        //Physics2D.IgnoreCollision(hit.collider, GetComponent<Collider2D>());
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
        //Debug.Log("TRIGGER: " + other.gameObject.tag);
        if (other.gameObject.tag == "Weapon" || other.gameObject.tag == "Charger")
            gameObject.GetComponent<Inventory>().Loot(other.gameObject);
        else if (other.gameObject.tag == "Battery")
            Light.GetComponent<FlashLight>().AddBattery(other.gameObject);
        else if (other.gameObject.tag == "MedicPack" && currentHealth < maxHealth)
        {
            currentHealth += other.gameObject.GetComponent<MedicPack>().health;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Victory")
            GameObject.Find("HUD").GetComponent<HUDHandler>().OnVictory();
    }

    private void OnDestroy() {
        GameObject.Find("HUD").GetComponent<HUDHandler>().OnGameOver();
    }
}