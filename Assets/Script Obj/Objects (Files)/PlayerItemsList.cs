using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Item Stuff/Player Items List")]
public class PlayerItemsList : ScriptableObject
{
  public List<PlayerItem> value;

  public void runActions() {
    for (int i = 0; i < value.Count; i++) {
      value[i].runActionIfShould();
    }
  }
}
