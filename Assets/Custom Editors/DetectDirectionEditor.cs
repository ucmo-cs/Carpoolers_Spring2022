using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// unity editor stuff; basically, it makes it so certain options are only available when they have been selected
// to be specific, which input value option is given to the user is based on which input value type is selected
// also, if the useScriptObj boolean is false, then the option to provide a scriptable object is removed
[CustomEditor(typeof(DetectDirection))]
[CanEditMultipleObjects]
public class DetectDirectionEditor : Editor
{
    SerializedProperty inputValueType;
    SerializedProperty moveInput;
    SerializedProperty moveInputSO;
    SerializedProperty useScriptObj;
    SerializedProperty directionSO;

    void OnEnable()
    {
        inputValueType = serializedObject.FindProperty("inputValueType");
        moveInput = serializedObject.FindProperty("moveInput");
        moveInputSO = serializedObject.FindProperty("moveInputSO");
        useScriptObj = serializedObject.FindProperty("useScriptObj");
        directionSO = serializedObject.FindProperty("directionSO");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(inputValueType);

        DetectDirection.InputType inputType = (DetectDirection.InputType)inputValueType.enumValueIndex;
        switch (inputType)
        {
            case DetectDirection.InputType.VECTOR:
                EditorGUILayout.PropertyField(moveInput);
                break;
            case DetectDirection.InputType.VECTOR_SO:
                EditorGUILayout.PropertyField(moveInputSO);
                break;
        }

        EditorGUILayout.PropertyField(useScriptObj);
        if (useScriptObj.boolValue) EditorGUILayout.PropertyField(directionSO);

        serializedObject.ApplyModifiedProperties();
    }
}
