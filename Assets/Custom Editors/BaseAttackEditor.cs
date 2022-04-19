using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseAttack))]
[CanEditMultipleObjects]
public class BaseAttackEditor : Editor
{
    SerializedProperty hitboxPrefab;
    SerializedProperty allowMultipleHitboxes;
    SerializedProperty useInputName;
    SerializedProperty inputName;
    SerializedProperty positionFromFront;
    SerializedProperty scale;
    SerializedProperty velocityFromFront;
    SerializedProperty dirFromScriptObj;
    SerializedProperty directionSO;
    SerializedProperty direction;
    SerializedProperty hitboxLength;
    SerializedProperty hitboxDelay;
    SerializedProperty damage;

    void OnEnable()
    {
        hitboxPrefab = serializedObject.FindProperty("hitboxPrefab");
        allowMultipleHitboxes = serializedObject.FindProperty("allowMultipleHitboxes");
        useInputName = serializedObject.FindProperty("useInputName");
        inputName = serializedObject.FindProperty("inputName");
        positionFromFront = serializedObject.FindProperty("positionFromFront");
        scale = serializedObject.FindProperty("scale");
        velocityFromFront = serializedObject.FindProperty("velocityFromFront");
        dirFromScriptObj = serializedObject.FindProperty("dirFromScriptObj");
        directionSO = serializedObject.FindProperty("directionSO");
        direction = serializedObject.FindProperty("direction");
        hitboxLength = serializedObject.FindProperty("hitboxLength");
        hitboxDelay = serializedObject.FindProperty("hitboxDelay");
        damage = serializedObject.FindProperty("damage");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        EditorGUILayout.PropertyField(allowMultipleHitboxes);

        EditorGUILayout.PropertyField(useInputName);
        if (useInputName.boolValue) EditorGUILayout.PropertyField(inputName);

        EditorGUILayout.PropertyField(damage);
        EditorGUILayout.PropertyField(hitboxDelay);
        EditorGUILayout.PropertyField(hitboxLength);
        EditorGUILayout.PropertyField(positionFromFront);
        EditorGUILayout.PropertyField(scale);
        EditorGUILayout.PropertyField(velocityFromFront);

        EditorGUILayout.PropertyField(hitboxPrefab);

        EditorGUILayout.PropertyField(dirFromScriptObj);
        if (dirFromScriptObj.boolValue) EditorGUILayout.PropertyField(directionSO);
        else EditorGUILayout.PropertyField(direction);

        serializedObject.ApplyModifiedProperties();
    }
}
