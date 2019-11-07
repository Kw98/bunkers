using UnityEngine;

public class melee : MonoBehaviour
{
    public  Animator    animator;
    public  int         damage;
    public  float       attackWidth;
    public  float       attackLength;
    public  Transform     attackPos;
    public  float       attackRate;
    private float      attackTime;
    public  LayerMask   enemiesLayer;

    // Start is called before the first frame update
    void Start()
    {
        attackTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && !Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("run");
        } else if (!Input.GetMouseButtonDown(0))
            animator.SetTrigger("idle");

        if (attackTime <= 0) {
            if (Input.GetMouseButtonDown(0)) {
                animator.SetTrigger("attack");
                attack(damage);
                attackTime = attackRate;
            }
        } else
            attackTime -= Time.deltaTime; 
    }

    private void    attack(int damages) {
        Collider2D[]    enemies = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackWidth, attackLength), 0, enemiesLayer);
        for (int i = 0; i < enemies.Length; i++) {
            // damage enemies
        }
    }

    // private void OnDrawGizmosSelected() {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireCube(attackPos.position, new Vector3(attackWidth, attackLength, 1));
    // }
}
