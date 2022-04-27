using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectOnStart : MonoBehaviour
{
    public StringSO spawnTag;
    public Vector2SO offset;

    void Start() {
        gameObject.transform.position = GameObject.Find(spawnTag.value).transform.position + (Vector3) offset.value;
    }
}
