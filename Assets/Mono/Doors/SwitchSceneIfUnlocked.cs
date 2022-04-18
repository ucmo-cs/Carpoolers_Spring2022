using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneIfUnlocked : MonoBehaviour
{
    public BoolSO isLocked;
    public string scene;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (!isLocked.value && scene.Length > 0) {
            SceneManager.LoadScene(scene);
        }
    }
}
