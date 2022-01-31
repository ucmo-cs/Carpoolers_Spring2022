using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// There is no asset menu for this because it should be inherited from
public class PlayerItem : ScriptableObject
{
  public BoolSO itemInput;

  private bool doingAction;

  protected void action() {
    doingAction = true;
    Debug.Log("Hi");
    doingAction = false;
  }

  protected bool shouldRunAction() {
    return itemInput.value && !doingAction;
  }

  public void runActionIfShould() {
    if (shouldRunAction()) action();
  }
}
