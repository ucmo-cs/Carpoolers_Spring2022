using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttackHitbox : MonoBehaviour
{
    public BaseAttack creator;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        creator.enteredAttack(collider2D);
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        creator.exitedAttack(collider2D);
    }
}
