using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOnCollisionSpecific : MonoBehaviour
{
    public string key;
    public StringListSO keys;
    public BoolSO isLocked;

    void OnCollisionEnter2D(Collision2D collision2D) {
        if (!keys.value.Contains(key)) return;

        keys.value.Remove(key);
        isLocked.value = false;
    }
}
