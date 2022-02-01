using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float")]
public class FloatSO : ScriptableObject
{
  public float value;

  private void OnEnable()
  {
    hideFlags = HideFlags.DontUnloadUnusedAsset;
  }
}
