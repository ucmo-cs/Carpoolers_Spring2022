using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyAfterCollision : MonoBehaviour
{
    public UnityEvent onCollisionEnter;

    public BoolSO isNotDestroyed; // not required

    private void onEnter() {
        onCollisionEnter.Invoke();
        if (isNotDestroyed) isNotDestroyed.value = false;
        Destroy(gameObject);
    }

    void Start() {
        if (isNotDestroyed && !isNotDestroyed.value) Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        onEnter();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        onEnter();
    }
}
