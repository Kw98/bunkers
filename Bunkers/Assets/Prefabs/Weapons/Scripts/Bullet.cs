using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float    speed = 1f;
    public int      damages;

    private void Update() {
        gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // add explosion effect and destroy it here
        Destroy(gameObject);
    }
}