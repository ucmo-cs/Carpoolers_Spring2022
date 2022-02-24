using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
        
    }

    public void exitedAttack(Collider2D collider)
    {

    }
}

[CustomEditor(typeof(BaseAttack))]
[CanEditMultipleObjects]
public class BaseAttackEditor : Editor
{
    SerializedProperty hitboxPrefab;
    SerializedProperty useInputName;
    SerializedProperty inputName;
    SerializedProperty positionFromFront;
    SerializedProperty scale;
    SerializedProperty dirFromScriptObj;
    SerializedProperty directionSO;
    SerializedProperty direction;
    SerializedProperty hitboxLength;
    SerializedProperty hitboxDelay;

    void OnEnable()
    {
        hitboxPrefab = serializedObject.FindProperty("hitboxPrefab");
        useInputName = serializedObject.FindProperty("useInputName");
        inputName = serializedObject.FindProperty("inputName");
        positionFromFront = serializedObject.FindProperty("positionFromFront");
        scale = serializedObject.FindProperty("scale");
        dirFromScriptObj = serializedObject.FindProperty("dirFromScriptObj");
        directionSO = serializedObject.FindProperty("directionSO");
        direction = serializedObject.FindProperty("direction");
        hitboxLength = serializedObject.FindProperty("hitboxLength");
        hitboxDelay = serializedObject.FindProperty("hitboxDelay");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(useInputName);
        if (useInputName.boolValue) EditorGUILayout.PropertyField(inputName);

        EditorGUILayout.PropertyField(hitboxDelay);
        EditorGUILayout.PropertyField(hitboxLength);
        EditorGUILayout.PropertyField(positionFromFront);
        EditorGUILayout.PropertyField(scale);

        EditorGUILayout.PropertyField(hitboxPrefab);

        EditorGUILayout.PropertyField(dirFromScriptObj);
        if (dirFromScriptObj.boolValue) EditorGUILayout.PropertyField(directionSO);
        else EditorGUILayout.PropertyField(direction);

        serializedObject.ApplyModifiedProperties();
    }
}
