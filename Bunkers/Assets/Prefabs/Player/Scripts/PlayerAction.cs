using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float    speed;
    public Rigidbody2D  rigidbody;
    [SerializeField] private Camera   camera;
    [SerializeField] private PhotonView photonView;
    public Animator legs;
    public Inventory inventory;
    private Vector2     movement;
    private Vector2         mousePos;

    private void Awake() {
        photonView = GetComponent<PhotonView>();
        if (photonView.isMine) {
            GameObject cam = GameObject.Find("Camera");
            print("HELLLOOOOOOOOOOOOOOOOOOO");
            if (cam)
                camera = cam.GetComponent<Camera>();
        }
    }

    private void Update() {
        if (!photonView.isMine)
            return;
        else if (currentHealth <= 0) {
            PhotonNetwork.Destroy(gameObject);
            return;
        }
        checkInputs();
    }

    private void    checkInputs() {
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
        if (!photonView.isMine)
            return;
        rigidbody.velocity = movement;
        Vector2 lookDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rigidbody.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D hit) {
        if (!photonView.isMine)
            return;
        if (hit.gameObject.tag == "Zombie")
            currentHealth -= 1.0f;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!photonView.isMine)
            return;
        if (other.gameObject.tag == "Weapon" || other.gameObject.tag == "Charger")
            gameObject.GetComponent<Inventory>().loot(other.gameObject);
    }
}