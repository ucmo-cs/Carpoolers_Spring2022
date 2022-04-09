using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOnCollision : MonoBehaviour
{
    public FloatSO keys;
    public BoolSO isLocked;

    void OnCollisionEnter2D(Collision2D collision2D) {
        if (keys.value < 1) return;

        keys.value--;
        isLocked.value = false;
    }
}
