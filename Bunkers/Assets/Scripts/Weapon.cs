using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WType {
        none,
        ak47,
        gun,
        silencegun,
        shotgun,
        uzi,
        m4,
        cub
    }

    public WType    wType;

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(gameObject.tag + " HAS COLLIDED");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(gameObject.tag + " HAS TRIGGERED");
    }
}
