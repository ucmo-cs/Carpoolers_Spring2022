using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    public GameObject hitboxPrefab;
    public bool useInputName;
    public string inputName = "";

    public Vector2 positionFromFront;
    public Vector2 scale = new Vector2(1, 1);

    public bool dirFromScriptObj;
    public DirectionSO directionSO;
    public Direction direction;

    public float hitboxLength;
    public float hitboxDelay;

    public float damage;

    private bool hitboxDelayCount;
    private float hitboxDelayCounter = 0;

    private Direction directionToUse;
    private GameObject hitbox;

    public void Update() {
        if (useInputName && Input.GetButtonDown(inputName)) onAttackInput();

        if (hitboxDelayCount) {
            hitboxDelayCounter += Time.deltaTime;

            if (hitboxDelayCounter >= hitboxDelay) {
                instantiateHitbox();

                hitboxDelayCount = false;
                hitboxDelayCounter = 0;
            }
        }
    }

    private void instantiateHitbox() {
        hitbox = Instantiate<GameObject>(hitboxPrefab, transform);
        hitbox.transform.localPosition = DirectionSO.rotatePosToCorrectDirection(positionFromFront, directionToUse);
        hitbox.transform.localScale = DirectionSO.rotateScaleToCorrectDirection(scale, directionToUse);
        hitbox.GetComponent<BaseAttackHitbox>().creator = this;
        Destroy(hitbox, hitboxLength);
    }

    public void onAttackInput() {
        if (hitbox) return;
        
        hitboxDelayCount = true;
        directionToUse = dirFromScriptObj ? directionSO.value : direction;
    }

    public void enteredAttack(Collider2D collider)
    {
        Health enemyHealth = collider.gameObject.GetComponent<Health>();

        if (!enemyHealth) return;

        enemyHealth.damageSelf(damage);
    }

    public void exitedAttack(Collider2D collider)
    {

    }
}
