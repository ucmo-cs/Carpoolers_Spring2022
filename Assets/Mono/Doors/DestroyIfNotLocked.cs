using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfNotLocked : MonoBehaviour
{
    public BoolSO isLocked;

    void Update()
    {
        if (!isLocked.value) Destroy(gameObject);
    }
}
