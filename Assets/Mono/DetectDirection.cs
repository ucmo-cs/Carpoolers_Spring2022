using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDirection : MonoBehaviour
{
    /**
     * There are two different types of input the script can use to detect direction:
     * Vector - the input value is directly provided by (assumedly) another script, i.e. this
     * script will assign the vector with detectDirectionVar.moveInput = new Vector2(input info)
     * this should be used in objects that cannot have their own scriptable object created, such as
     * a standard enemy that will be generated at runtime
     * 
     * VectorSO - the input value is provided through a scriptable object; another script will
     * change the value of the scriptable object, which will in turn affect this script. This
     * should be used whenever possible, such as for the player
     *
     * also, in both cases, you should use a raw version of the inputs, i.e. a vector2 that shows
     * 1 when the object is inputting one way, -1 when the object is inputting another, and 0 when
     * nothing is inputted. It's noted where in the code this would be a problem
    **/
    public enum InputType
    {
        VECTOR,
        VECTOR_SO,
    };

    public InputType inputValueType;
    public Vector2 moveInput;
    public Vector2SO moveInputSO;

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

            // if we weren't taking in the raw input, this wouldn't 100% work, since, for example, if the object
            // takes some time to slow down, and the object was moving left and down while facing left, and the
            // object stopped inputting left, the object wouldn't face down until it had completely slowed down
            // going left, since inputValue.x and inputValue.y would both != 0 despite the object not inputting
            // in both ways
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
