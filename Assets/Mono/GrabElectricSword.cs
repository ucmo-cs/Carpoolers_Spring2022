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
        if (collisionInfo.gameObject.tag == "Player")
        {
            if (!hasElectricSword.value)
            {
                grabElectricSword(true);
                unlockElectricGates(false);
                lockEmergencyDoors(true);
            }
            else // mostly for testing purposes, you can put the sword back
            {
                grabElectricSword(false);
                unlockElectricGates(true);
                lockEmergencyDoors(false);
            }
        }
    }

    void grabElectricSword(bool value)
    {
        hasElectricSword.value = value;
    }

    void unlockElectricGates(bool value)
    {
        isElectricGateLocked.value = value;
    }

    void lockEmergencyDoors(bool value)
    {
        if (individualEmergencyDoorLocks.Count > 0)
        {
            individualEmergencyDoorLocks.ForEach(delegate (BoolSO emergencyDoorLock)
            {
                emergencyDoorLock.value = value;
            });
        }
    }
}
