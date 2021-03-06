using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanzer : MonoBehaviour {

    public float speed = 1;
    
    private Transform tr;
    private Rigidbody2D rb;
    private ShotController shotController;

    private Vector2 input;

    void Start() {
        tr = transform;
        rb = GetComponent<Rigidbody2D>();
        shotController = GetComponent<ShotController>();
    }

    void Update() {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        if (input.magnitude > 0) {
            //in order for the direction to be unambiguous (up / down / left / right)
            float rotation = Vector2.SignedAngle(Vector2.up, input);
            float rotationRounded = Mathf.Round(rotation / 90);
            rb.rotation = rotationRounded * 90;
        }

        if (Input.GetButtonDown("Fire1")) {
            shotController.Shoot();
        }
    }

    private void FixedUpdate() {
        float magnitude = Mathf.Max(Mathf.Abs(input.x), Mathf.Abs(input.y));
        rb.velocity = transform.up * magnitude * speed;
    }
}
