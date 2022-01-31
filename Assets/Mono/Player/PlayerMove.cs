using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  public float speed;
  public Vector2SO moveInput;

  private Rigidbody2D rb;
  private Vector2 velocity;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    velocity = moveInput.value * speed;
  }

  void FixedUpdate()
  {
    rb.velocity = velocity;
  }
}
