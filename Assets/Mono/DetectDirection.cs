using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DetectDirection : MonoBehaviour
{
    /**
     * There are three different types of input the script can use to detect direction:
     * Vector - the input value is directly provided by (assumedly) another script, i.e. this
     * script will assign the vector with detectDirectionVar.moveInput = new Vector2(input info)
     * this should be used in objects that cannot have their own scriptable object created, such as
     * a standard enemy that will be generated at runtime
     * 
     * VectorSO - the input value is provided through a scriptable object; another script will
     * change the value of the scriptable object, which will in turn affect this script. This
     * should be used whenever possible, such for the player
     *
     * Rigidbody - the input value is provided by the velocity of the object, which is prone to
     * error (ex. if an object is inputting into a heavy wind that is blowing them in the opposite
     * direction); however, it is easiest to set up, so I guess you can use it if you're feeling
     * lazy, just know that there might be issues if other physics affect the object
    **/
    public enum InputType
    {
        VECTOR,
        VECTOR_SO,
        RIGIDBODY,
    };

    public InputType inputValueType;
    public Vector2 moveInput;
    public Vector2SO moveInputSO;
    public Rigidbody2D rb;

    /**
     * The direction this script calculates can be accessed via either the direction attribute (i.e.
     * using detectDirectionVar.direction) or via a scriptable object, which should generally be
     * the desired choice when possible (i.e. whenever the object can have its own individual
     * scriptable object given to it)
    **/
    public bool useScriptObj;
    public DirectionSO directionSO;

    public Direction direction = Direction.SOUTH;
    private Direction prevDirection = Direction.NULL;

    void Update()
    {
        // gets the current input
        Vector2 inputValue;

        switch (inputValueType)
        {
            case InputType.VECTOR:
                inputValue = moveInput;
                break;
            case InputType.VECTOR_SO:
                inputValue = moveInputSO.value;
                break;
            case InputType.RIGIDBODY:
                inputValue = rb.velocity;
                break;
            default:
                inputValue = new Vector2(0, 0);
                break;
        }

        Direction horizDir = inputValue.x > 0 ? Direction.EAST : Direction.WEST;
        Direction vertiDir = inputValue.y > 0 ? Direction.NORTH : Direction.SOUTH;

        // if the object is moving along the horizontal and vertical axises, find the correct direction
        if (inputValue.x != 0 && inputValue.y != 0)
        {
            // if the previous direction hasn't been set, set it to the current direction
            if (prevDirection == Direction.NULL) prevDirection = direction;

            // change the direction to the most recent direction, i.e. the one that isn't the previous direction
            direction = horizDir == prevDirection ? vertiDir : horizDir;
        }

        else
        {
            prevDirection = Direction.NULL;

            if (inputValue.x != 0) direction = horizDir;
            if (inputValue.y != 0) direction = vertiDir;
        }

        if (useScriptObj) directionSO.value = direction;
    }

    public Direction getDirection()
    {
        return direction;
    }
}

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
    SerializedProperty rb;
    SerializedProperty useScriptObj;
    SerializedProperty directionSO;

    void OnEnable()
    {
        inputValueType = serializedObject.FindProperty("inputValueType");
        moveInput = serializedObject.FindProperty("moveInput");
        moveInputSO = serializedObject.FindProperty("moveInputSO");
        rb = serializedObject.FindProperty("rb");
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
            case DetectDirection.InputType.RIGIDBODY:
                EditorGUILayout.PropertyField(rb);
                break;
        }

        EditorGUILayout.PropertyField(useScriptObj);
        if (useScriptObj.boolValue) EditorGUILayout.PropertyField(directionSO);

        serializedObject.ApplyModifiedProperties();
    }
}
