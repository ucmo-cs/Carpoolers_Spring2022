using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Boolean")]
public class BoolSO : ScriptableObject
{
  public bool value;

  private void OnEnable() {
    hideFlags = HideFlags.DontUnloadUnusedAsset;
  }
}
