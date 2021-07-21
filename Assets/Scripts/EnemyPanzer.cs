using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPanzer : MonoBehaviour
{
    [Header("Movement")]
    public Transform target;
    public float speed = 3;
    public float moveTimeStep = 0.2f;
    public float sleepAfterTurn = 0.5f;

    [Header("Shooting")]
    public float minShootPeriod = 0.5f;
    public float maxShootPeriod = 2;
    private float shootPeriod = 0.5f;
    private float shootTimer;

    [Header("Raycast")]
    public LayerMask hitLayerMask;
    public float hitRadius = 0.3f;


    private Transform tr;
    private Rigidbody2D rb;
    private ShotController shotController;
    private CircleCollider2D col;

    private Vector2 input;

    private bool forwardBlocked;
    private bool turnDetected;

    // Start is called before the first frame update
    void Start() {
        tr = transform;
        rb = GetComponent<Rigidbody2D>();
        shotController = GetComponent<ShotController>();
        col = GetComponent<CircleCollider2D>();

        StartCoroutine(Control());
    }

    void FixedUpdate() {
        rb.velocity = transform.up * speed;
    }

    IEnumerator Control() {
        while (true) {
            yield return new WaitForSeconds(moveTimeStep);

            if(shootTimer < shootPeriod) {
                shootTimer += moveTimeStep;
            } else {
                shotController.Shoot();
                shootPeriod = Random.Range(minShootPeriod, maxShootPeriod);
                shootTimer = 0;
            }

            RaycastHit2D hitForward = Physics2D.CircleCast(tr.position, hitRadius, tr.up, hitRadius, hitLayerMask);
            RaycastHit2D hitLeft = Physics2D.CircleCast(tr.position, hitRadius, -tr.right, hitRadius, hitLayerMask);
            RaycastHit2D hitRight = Physics2D.CircleCast(tr.position, hitRadius, tr.right, hitRadius, hitLayerMask);
            RaycastHit2D hitBack = Physics2D.CircleCast(tr.position, hitRadius, -tr.up, hitRadius, hitLayerMask);

            if (!forwardBlocked && hitForward) {
                forwardBlocked = true;
            }

            if (!turnDetected && (!hitLeft || !hitRight)) {
                turnDetected = true;
            }

            if (forwardBlocked || turnDetected) {
                List<int> ways = new List<int>();
                if (!hitForward)
                    ways.Add(0);
                if (!hitLeft)
                    ways.Add(90);
                if (!hitRight)
                    ways.Add(-90);
                if (!hitBack)
                    ways.Add(180);

                if (ways.Count > 0) {
                    int randomSide = Random.Range(0, ways.Count);
                    rb.rotation += ways[randomSide];
                }
                
                forwardBlocked = false;
                turnDetected = false;

                yield return new WaitForSeconds(sleepAfterTurn);
            }

        }
    }
}
