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

    [Header("Shake")]
    public Transform cam;
    public float shakeRange = 0.1f;
    public float shakePeriod = 0.1f;
    public int shakeCount = 10;

    private void Awake() {
        instance = this;
        
    }

    public static void PlayBoomEffect(Vector2 position) {
        instance.boomParticles.transform.position = position;
        instance.boomParticles.Play();
        instance.boomSound.Play();

        instance.StartCoroutine(instance.HitShakeEffectCoroutine());
    }
    public static void PlayShootEffect() {
        instance.shootSound.Play();
    }
    public static void PlaySpawnEffect(Vector2 position) {
        instance.spawnParticles.transform.position = position;
        instance.spawnParticles.Play();
    }

    IEnumerator HitShakeEffectCoroutine() {
        for (int i = 0; i < shakeCount; i++) {
            yield return new WaitForSecondsRealtime(shakePeriod);

            Vector3 offset = Vector3.zero;
            offset.x = Random.Range(-shakeRange, shakeRange);
            offset.y = Random.Range(-shakeRange, shakeRange);
            offset.z = Random.Range(-shakeRange, shakeRange);
            cam.localPosition = offset;
        }
        cam.localPosition = Vector3.zero;
    }
}