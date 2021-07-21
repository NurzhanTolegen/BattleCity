using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    public static ParticlesController instance;

    public ParticleSystem boom;

    private void Awake() {
        instance = this;
    }

    public static void SetBoomParticles(Vector2 position) {
        instance.boom.transform.position = position;
        instance.boom.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
