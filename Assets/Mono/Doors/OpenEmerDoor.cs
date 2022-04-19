using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEmerDoor : MonoBehaviour
{
    public BoolSO isEmerDoorLocked;
    public BoolSO hasElectricSword;

    void OnTriggerEnter2D(Collider2D colliderInfo)
    {
        if (colliderInfo.gameObject.tag == "Player" && hasElectricSword) {
            isEmerDoorLocked.value = false;
        }
    }
}
