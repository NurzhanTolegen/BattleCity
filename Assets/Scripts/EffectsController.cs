using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoBehaviour
{
    public static EffectsController instance;

    [Header("Shoot")]
    public AudioSource shootSound;

    [Header("Boom")]
    public ParticleSystem boomParticles;
    public AudioSource boomSound;

    private void Awake() {
        instance = this;
        
    }

    public static void PlayBoomEffect(Vector2 position) {
        instance.boomParticles.transform.position = position;
        instance.boomParticles.Play();
        instance.boomSound.Play();
    }
    public static void PlayShootEffect(Transform shotPoint) {
        instance.shootSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Effect {
    public string name = "Effect";
    public ParticleSystem particleSystem;
    public AudioSource audioSource;
}
