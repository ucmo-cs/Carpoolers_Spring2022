using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementInput : MonoBehaviour
{
    public static string HORIZONTAL_AXIS = "Horizontal";
    public static string VERTICAL_AXIS = "Vertical";

    public Vector2SO moveInput;

    void Update()
    {
        if (moveInput) moveInput.value = new Vector2(Input.GetAxis(HORIZONTAL_AXIS), Input.GetAxis(VERTICAL_AXIS));
    }
}
