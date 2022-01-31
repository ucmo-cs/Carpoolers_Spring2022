using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flag")]
public class Flag : ScriptableObject
{
  public bool value;

  private void OnEnable() {
    hideFlags = HideFlags.DontUnloadUnusedAsset;
  }
}
