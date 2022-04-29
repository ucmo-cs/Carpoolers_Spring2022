using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool healthIsSO;
    public float currHealth;
    public FloatSO currHealthSO;
    public bool maxHealthIsSO;
    public float maxHealth;
    public FloatSO maxHealthSO;
    public string team;

    public void damageSelf(float damage)
    {
        if (healthIsSO) currHealthSO.value -= damage;
        else currHealth -= damage;
    }
}
