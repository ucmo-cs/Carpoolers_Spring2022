using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabElectricSword : MonoBehaviour
{
    public BoolSO hasElectricSword;
    public BoolSO isElectricGateLocked;
    public List<BoolSO> individualEmergencyDoorLocks;

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player" && !hasElectricSword.value)
        {
            grabElectricSword();
            unlockElectricGates();
            lockEmergencyDoors();
        }
    }

    void grabElectricSword()
    {
        hasElectricSword.value = true;
    }

    void unlockElectricGates()
    {
        isElectricGateLocked.value = false;
    }

    void lockEmergencyDoors()
    {
        if (individualEmergencyDoorLocks.Count > 0)
        {
            individualEmergencyDoorLocks.ForEach(delegate (BoolSO emergencyDoorLock)
            {
                emergencyDoorLock.value = true;
            });
        }
    }
}
