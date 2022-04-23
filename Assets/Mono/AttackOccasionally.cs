using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOccasionally : MonoBehaviour
{
    public float initialDelay;
    public float timeBetweenAttacks;
    public BaseAttack attack;

    private bool inInitialStage = true;
    private float counter;

    void Start()
    {
        if (!attack) attack = GetComponent<BaseAttack>();
        if (!attack) Debug.Log("Error: no BaseAttack component found");
    }

    void Update()
    {
        if (!attack) return;

        counter += Time.deltaTime;

        bool pastInitialDelay = inInitialStage && counter >= initialDelay;
        bool pastTimeBetweenAttacks = !inInitialStage && counter >= timeBetweenAttacks;

        if ((pastInitialDelay || pastTimeBetweenAttacks) && attack.onAttackInput())
        {
            inInitialStage = false;
            counter = 0;
        }
    }
}
