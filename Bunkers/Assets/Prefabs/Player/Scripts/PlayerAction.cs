using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float    speed;
    public Rigidbody2D  rigidbody;
    public Camera   camera;
    public Animator legs;
    private Vector2     movement;
    private Vector2         mousePos;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A))
            gameObject.GetComponent<Inventory>().drop();
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        legs.SetFloat("Run", movement.x + movement.y);
    }


    private void FixedUpdate() {
        rigidbody.velocity = movement;
        Vector2 lookDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rigidbody.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collided");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Triggered");
            if (other.gameObject.tag == "Weapon" || other.gameObject.tag == "Charger")
                gameObject.GetComponent<Inventory>().loot(other.gameObject);
    }
}