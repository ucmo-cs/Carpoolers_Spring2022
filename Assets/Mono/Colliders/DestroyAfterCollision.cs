using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyAfterCollision : MonoBehaviour
{
    public UnityEvent onCollisionEnter;

    void OnCollisionEnter2D(Collision2D collision)
    {
        onCollisionEnter.Invoke();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        onCollisionEnter.Invoke();
        Destroy(gameObject);
    }
}
