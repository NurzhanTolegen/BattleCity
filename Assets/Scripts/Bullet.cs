using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1;
    public float velocity = 10;

    private Transform tr;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        tr = transform;
        rb = GetComponent<Rigidbody2D>();

        SetImpulse();
    }

    void SetImpulse() {
        rb.AddForce(tr.up * velocity, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals(gameObject.tag)) return;

        ParticlesController.SetBoomParticles(rb.position);
        Destroy(gameObject);
        Debug.Log("" + collision.gameObject.name);
    }
}

