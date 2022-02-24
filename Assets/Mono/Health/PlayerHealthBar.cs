using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthBar;
    public FloatSO playerHealth;
    public FloatSO maxHealth;

    void Start()
    {
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = maxHealth.value;
    }

    void Update() {
        healthBar.value = playerHealth.value;
    }
}
