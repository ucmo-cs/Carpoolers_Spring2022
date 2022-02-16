using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FloatSO speed;
    public Vector2SO moveInput;
    public Rigidbody2D rigidbody2d;

    private Vector2 velocity;

    void Update()
    {
        velocity = speed.value * moveInput.value;
    }

    void FixedUpdate()
    {
        rigidbody2d.velocity = velocity;
    }
}
