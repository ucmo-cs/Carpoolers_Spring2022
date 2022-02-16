using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DetectDirection : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool useScriptObj;
    public DirectionSO directionSO;

    private Direction direction = Direction.SOUTH;
    private Direction prevDirection = Direction.NULL;

    void Update()
    {
        // gets the current velocity of the parent
        Vector2 velocity = rb.velocity;

        // if the player isn't moving, don't change the direction
        if (velocity.x == 0 && velocity.y == 0)
        {
            prevDirection = Direction.NULL;
        }

        // if the player is moving along the horizontal and vertical axises, find the correct direction
        else if (velocity.x != 0 && velocity.y != 0)
        {
            Direction horizDir = velocity.x > 0 ? Direction.EAST : Direction.WEST;
            Direction vertiDir = velocity.y > 0 ? Direction.NORTH : Direction.SOUTH;

            // if the previous direction hasn't been set, set it to the current direction
            if (prevDirection == Direction.NULL) prevDirection = direction;

            // change the direction to the most recent direction, i.e. the one that isn't the previous direction
            direction = horizDir == prevDirection ? vertiDir : horizDir;
        }

        else if (velocity.x != 0) direction = velocity.x > 0 ? Direction.EAST : Direction.WEST;
        else if (velocity.y != 0) direction = velocity.y > 0 ? Direction.NORTH : Direction.SOUTH;

        if (useScriptObj) directionSO.value = direction;
    }

    public Direction getDirection()
    {
        return direction;
    }
}

[CustomEditor(typeof(DetectDirection))]
[CanEditMultipleObjects]
public class DetectDirectionEditor : Editor
{
    SerializedProperty useScriptObj;
    SerializedProperty directionSO;
    SerializedProperty rb;

    void OnEnable()
    {
        useScriptObj = serializedObject.FindProperty("useScriptObj");
        directionSO = serializedObject.FindProperty("directionSO");
        rb = serializedObject.FindProperty("rb");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(rb);
        EditorGUILayout.PropertyField(useScriptObj);
        if (useScriptObj.boolValue) EditorGUILayout.PropertyField(directionSO);

        serializedObject.ApplyModifiedProperties();
    }
}
