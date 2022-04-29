using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    public GameObject hitboxPrefab;
    public bool allowMultipleHitboxes;
    public bool useInputName;
    public string inputName = "";

    public bool allowTeamDamage = true;
    public string team;

    public Vector2 positionFromFront;
    public Vector2 scale = new Vector2(1, 1);
    public Vector2 colliderScale = new Vector2(1, 1);
    public Vector2 velocityFromFront;

    public bool dirFromScriptObj;
    public DirectionSO directionSO;
    public Direction direction;

    public float hitboxLength;
    public float hitboxDelay;

    public float damage;

    private bool hitboxDelayCount;
    private float hitboxDelayCounter = 0;

    private Direction directionToUse;
    private List<GameObject> hitboxes = new List<GameObject>();

    public void Update() {
        for (int i = hitboxes.Count - 1; i >= 0; i--) {
            if (!hitboxes[i]) hitboxes.RemoveAt(i);
        }

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
        GameObject hitbox = Instantiate<GameObject>(hitboxPrefab, transform);
        hitbox.transform.localPosition = DirectionSO.rotatePosToCorrectDirection(positionFromFront, directionToUse);
        hitbox.transform.localScale = DirectionSO.rotateScaleToCorrectDirection(scale, directionToUse);
        hitbox.transform.rotation = Quaternion.Euler(DirectionSO.getRotation(hitbox.transform.rotation.eulerAngles, directionToUse));
        hitbox.GetComponent<Rigidbody2D>().velocity = DirectionSO.rotatePosToCorrectDirection(velocityFromFront, directionToUse);
        hitbox.GetComponent<BaseAttackHitbox>().creator = this;
        hitbox.GetComponent<BoxCollider2D>().size = colliderScale;
        if (hitboxLength != -1) Destroy(hitbox, hitboxLength);

        hitboxes.Add(hitbox);
    }

    public bool onAttackInput() {
        if (!allowMultipleHitboxes && hitboxes.Count > 0) return false;
        
        hitboxDelayCount = true;
        directionToUse = dirFromScriptObj ? directionSO.value : direction;

        return true;
    }

    public void enteredAttack(Collider2D collider)
    {
        Health enemyHealth = collider.gameObject.GetComponent<Health>();

        if (!enemyHealth) return;
        if (!allowTeamDamage && team == enemyHealth.team) return;

        enemyHealth.damageSelf(damage);
    }

    public void exitedAttack(Collider2D collider)
    {

    }
}
