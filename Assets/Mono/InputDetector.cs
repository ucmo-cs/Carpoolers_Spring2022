using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDetector : MonoBehaviour
{
  public Vector2SO moveInput;
  public BoolSO testItemInput;

  public void OnMove(InputValue input) {
    moveInput.value = input.Get<Vector2>();
  }

  public void OnTestItem(InputValue input) {
    testItemInput.value = input.Get<float>() == 1;
  }
}
