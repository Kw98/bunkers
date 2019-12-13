using UnityEngine;

public class melee : MonoBehaviour
{
    public  Animator    animator;
    public  int         damage;
    public  float       attackWidth;
    public  float       attackLength;
    public  Transform     attackPos;
    public  float       attackRate;
    private float      nextAttack;
    private bool        isAttacking;
    public  LayerMask   enemiesLayer;

    // Start is called before the first frame update
    void Start()
    {
        nextAttack = 0;
    }

    public void Updater() {
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("run");
        } else if (!Input.GetMouseButtonDown(0))
            animator.SetTrigger("idle");

        if (Input.GetMouseButtonUp(0))
            isAttacking = false;
        if (Input.GetMouseButtonDown(0))
            isAttacking = true;

        if (isAttacking && Time.time > nextAttack) {
            animator.SetTrigger("attack");
            attack();
            nextAttack = Time.time + attackRate;
        }
    }

    private void    attack() {
        Collider2D[]    objs = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackWidth, attackLength), 0);
        foreach (Collider2D obj in objs) {
            if (obj.gameObject.tag == "Zombie") {
                if (obj.gameObject.GetComponent<ZombieMvt>().CurrentHealth - damage <= 0f)
                    Physics2D.IgnoreCollision(obj, GetComponent<Collider2D>());
                obj.gameObject.GetComponent<ZombieMvt>().CurrentHealth -= damage;
            }
        }
    }
}
