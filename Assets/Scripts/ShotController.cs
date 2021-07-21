using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public Transform shotPoint;
    public Bullet bulletPrefab;
    public ParticleSystem shootParticle;

    public float shootPeriod = 0.2f;
    public bool CanShoot {
        get => timer >= shootPeriod;
    }

    private float timer;

    private Collider2D col;
    private Transform tr;

    void Awake() {
        tr = transform;
        col = GetComponent<Collider2D>();
    }

    public void Shoot() {
        if (!CanShoot) return;

        Bullet bullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
        Physics2D.IgnoreCollision(col, bullet.col);

        EffectsController.PlayShootEffect();
        shootParticle.Play();

        timer = 0;
    }

    // Update is called once per frame
    void Update() {
        if (timer < shootPeriod) {
            timer += Time.deltaTime;
        }
        
    }
}
