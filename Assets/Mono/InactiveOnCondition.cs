using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveOnCondition : MonoBehaviour
{
    public Behaviour component;
    public BoolSO condition;
    public bool flipCondition;

    void Update() {
        if (flipCondition ? !condition.value : condition.value) component.enabled = false;
        else component.enabled = true;
    }
}
