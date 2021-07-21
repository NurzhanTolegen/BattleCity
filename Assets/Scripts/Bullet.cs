using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int damage = 1;
    public float velocity = 10;

    private Transform tr;
    private Rigidbody2D rb;
    [HideInInspector]
    public Collider2D col;

    void Awake() {
        tr = transform;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        SetImpulse();
    }

    void SetImpulse() {
        rb.AddForce(tr.up * velocity, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string tag = collision.gameObject.tag;

        EffectsController.PlayBoomEffect(collision.contacts[0].point);
        Destroy(gameObject);

        if (tag.Equals("Enemy") || tag.Equals("Player")) {
            Health health = collision.gameObject.GetComponent<Health>();
            health.Damage(damage);
        } else if (tag.Equals("Bricks")) {
            TileDestroyController.DestroyTiles(collision.contacts, 1);
        }
    }
}

