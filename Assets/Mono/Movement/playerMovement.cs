using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static string HORIZONTAL_AXIS = "Horizontal";
    public static string VERTICAL_AXIS = "Vertical";

    public FloatSO speed;
    public Rigidbody2D rigidbody2d;

    private Vector2 velocity;

    void Update()
    {
        velocity = speed.value * new Vector2(Input.GetAxis(HORIZONTAL_AXIS), Input.GetAxis(VERTICAL_AXIS));
    }

    void FixedUpdate()
    {
        rigidbody2d.velocity = velocity;
    }
}
