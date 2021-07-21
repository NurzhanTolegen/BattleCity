using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public Transform shotPoint;
    public Bullet bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Shoot() {
        Bullet bullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
