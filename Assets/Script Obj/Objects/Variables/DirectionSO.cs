using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Direction")]
public class DirectionSO : ScriptableObject
{
    public Direction value;

    // fun fact about scriptable objects: they can be used in the editor to store data between scenes,
    // but in the build they only are stored if the object is used in that scene; otherwise, they
    // return to their default. This code here makes it so the scriptable object works the same in
    // build as it does in the editor.
    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    // this function assumes the distance is with regards to north
    public static Vector2 rotatePosToCorrectDirection(Vector2 distance, Direction direction) {
        switch (direction) {
            case Direction.EAST:
                return new Vector2(distance.y, distance.x * -1);
            case Direction.SOUTH:
                return new Vector2(distance.x, distance.y * -1);
            case Direction.WEST:
                return new Vector2(distance.y * -1, distance.x);
            default:
                return distance;
        }
    }

    public static Vector2 rotateScaleToCorrectDirection(Vector2 scale, Direction direction) {
        switch (direction) {
            case Direction.EAST:
            case Direction.WEST:
                return new Vector2(scale.y, scale.x);
            default:
                return scale;
        }
    }
}
