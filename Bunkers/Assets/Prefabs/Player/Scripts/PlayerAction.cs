using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    private Transform   tr;
    private Camera  cam;
    private Vector3 mousePos;
    public Animator legsAnim;
    private Inventory    inventory;


    private void Awake() {
        inventory = GetComponent<Inventory>();
        body = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start() {
        mousePos = getMousePos();
    }

    private void FixedUpdate() {
        mousePos = getMousePos();
        // move
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        body.velocity = new Vector2(xSpeed, ySpeed);
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
            legsAnim.SetBool("isRunning", true);
        } else
            legsAnim.SetBool("isRunning", false);
        // look at
        float   angle = Mathf.Atan2(mousePos.y - tr.position.y, mousePos.x - tr.position.x) * Mathf.Rad2Deg;
        tr.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    private Vector3 getMousePos() {
        return cam.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.y - tr.position.y));
    }

    private void    lootWeapon(GameObject Weapon) {
        for (int i = 0; i < transform.childCount; i++) {
            GameObject check = transform.GetChild(i).gameObject;
            if (check.tag == "Weapon") {
                if (check.GetComponent<Weapon>().wType == Weapon.GetComponent<Weapon>().wType) {
                    Destroy(check);
                    break;
                }
            }
        }
        Weapon.transform.parent = gameObject.transform;
        Weapon.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject obj = other.gameObject;

        Debug.Log("COLLISION");
        if (obj.tag == "Weapon") {
            if (inventory.loot(obj))
                lootWeapon(obj);
        }
    }
}
