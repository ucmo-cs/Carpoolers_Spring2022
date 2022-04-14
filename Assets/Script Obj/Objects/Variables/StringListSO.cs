using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/List<String>")]
public class StringListSO : ScriptableObject
{
    public List<string> value;

    public void add(string newString) {
        value.Add(newString);
    }

    // fun fact about scriptable objects: they can be used in the editor to store data between scenes,
    // but in the build they only are stored if the object is used in that scene; otherwise, they
    // return to their default. This code here makes it so the scriptable object works the same in
    // build as it does in the editor.
    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}
