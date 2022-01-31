using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
  public PlayerItemsList playerItems;

  void Update() {
    playerItems.runActions();
  }
}
