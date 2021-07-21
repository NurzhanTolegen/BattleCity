using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health = 1;

    public UnityEvent onDeath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Damage(int damage) {
        health -= damage;
        if(health <= 0) {
            Death();
        }
    }

    void Death() {
        Destroy(gameObject);
        EffectsController.PlayBoomEffect(transform.position);
        onDeath.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
