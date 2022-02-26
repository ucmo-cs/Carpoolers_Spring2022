using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Health : MonoBehaviour
{
    public bool healthIsSO;
    public float currHealth;
    public FloatSO currHealthSO;
    public bool maxHealthIsSO;
    public float maxHealth;
    public FloatSO maxHealthSO;

    public void damageSelf(float damage)
    {
        if (healthIsSO) currHealthSO.value -= damage;
        else currHealth -= damage;
    }
}

[CustomEditor(typeof(Health))]
[CanEditMultipleObjects]
public class HealthEditor : Editor 
{
    SerializedProperty healthIsSO;
    SerializedProperty currHealth;
    SerializedProperty currHealthSO;
    SerializedProperty maxHealthIsSO;
    SerializedProperty maxHealth;
    SerializedProperty maxHealthSO;
    
    void OnEnable()
    {
        healthIsSO = serializedObject.FindProperty("healthIsSO");
        currHealth = serializedObject.FindProperty("currHealth");
        currHealthSO = serializedObject.FindProperty("currHealthSO");
        maxHealthIsSO = serializedObject.FindProperty("maxHealthIsSO");
        maxHealth = serializedObject.FindProperty("maxHealth");
        maxHealthSO = serializedObject.FindProperty("maxHealthSO");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(healthIsSO);
        if (healthIsSO.boolValue) EditorGUILayout.PropertyField(currHealthSO);
        else EditorGUILayout.PropertyField(currHealth);

        EditorGUILayout.PropertyField(maxHealthIsSO);
        if (maxHealthIsSO.boolValue) EditorGUILayout.PropertyField(maxHealthSO);
        else EditorGUILayout.PropertyField(maxHealth);

        serializedObject.ApplyModifiedProperties();
    }
}
