using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCollider : MonoBehaviour
{
  public UnityEvent onCollisionEnter;
  public UnityEvent onCollisionExit;

  void OnCollisionEnter2D(Collision2D collision)
  {
    onCollisionEnter.Invoke();
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
    onCollisionEnter.Invoke();
  }

  void OnCollisionExit2D(Collision2D collision)
  {
    onCollisionExit.Invoke();
  }

  void OnTriggerExit2D(Collider2D collider)
  {
    onCollisionExit.Invoke();
  }
}
