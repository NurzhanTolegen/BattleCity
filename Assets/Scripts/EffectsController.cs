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

    [Header("Spawn")]
    public ParticleSystem spawnParticles;

    private void Awake() {
        instance = this;
        
    }

    public static void PlayBoomEffect(Vector2 position) {
        instance.boomParticles.transform.position = position;
        instance.boomParticles.Play();
        instance.boomSound.Play();
    }
    public static void PlayShootEffect() {
        instance.shootSound.Play();
    }
    public static void PlaySpawnEffect(Vector2 position) {
        instance.spawnParticles.transform.position = position;
        instance.spawnParticles.Play();
    }

}