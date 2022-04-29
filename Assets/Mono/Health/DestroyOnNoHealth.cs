using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnNoHealth : MonoBehaviour
{
    public Health health;

    void Update() {
        if (health.currHealth <= 0) destroySelf();
    }

    public void destroySelf() {
        Destroy(gameObject);
    }
}
