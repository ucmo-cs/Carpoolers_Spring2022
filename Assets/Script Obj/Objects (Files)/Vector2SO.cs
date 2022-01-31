using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Vector2")]
public class Vector2SO : ScriptableObject
{
  public Vector2 value;

  private void OnEnable() {
    hideFlags = HideFlags.DontUnloadUnusedAsset;
  }
}
