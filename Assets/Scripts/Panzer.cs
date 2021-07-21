using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panzer : MonoBehaviour {

    public float speed = 1;
    public float lerpSpeed = 20;

    private Transform tr;
    private Rigidbody2D rb;
    private ShotController shotController;

    private Vector2 input;
    private float targetRotation;

    // Start is called before the first frame update
    void Start() {
        tr = transform;
        rb = GetComponent<Rigidbody2D>();
        shotController = GetComponent<ShotController>();
    }

    // Update is called once per frame
    void Update() {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        if (input.magnitude > 0) {
            float rotation = Vector2.SignedAngle(Vector2.up, input);
            float rotationRounded = Mathf.Round(rotation / 90);
            targetRotation = rotationRounded * 90;
        }

        rb.rotation = targetRotation;

        if (Input.GetButtonDown("Fire1")) {
            shotController.Shoot();
        }
    }

    private void FixedUpdate() {
        float magnitude = Mathf.Max(Mathf.Abs(input.x), Mathf.Abs(input.y));
        rb.velocity = transform.up * magnitude * speed;
    }
}
