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
    private Vector2     movement;
    private Vector2         mousePos;
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private GameObject VictoryMenu;

    private void Update() {
        if (currentHealth <= 0) {
            Destroy(gameObject);
            return;
        }
        if (Input.GetKeyDown(KeyCode.A))
            gameObject.GetComponent<Inventory>().drop();
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        legs.SetFloat("Run", movement.x + movement.y);
        if (inventory.actualEquiped != -1)
            inventory.weapons[inventory.actualEquiped].transform.Find("Equiped").gameObject.GetComponent<range>().Updater();
        else
            inventory.melee.GetComponent<melee>().Updater();
    }


    private void FixedUpdate() {
        rigidbody.velocity = movement;
        Vector2 lookDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rigidbody.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D hit) {
        if (hit.gameObject.tag == "Zombie")
            currentHealth -= 1.0f;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Triggered");
            if (other.gameObject.tag == "Weapon" || other.gameObject.tag == "Charger")
                gameObject.GetComponent<Inventory>().loot(other.gameObject);
        if (other.gameObject.tag == "Victory")
            VictoryMenu.SetActive(true);
    }

    private void OnDestroy() {
        GameOverMenu.SetActive(true);
    }
}