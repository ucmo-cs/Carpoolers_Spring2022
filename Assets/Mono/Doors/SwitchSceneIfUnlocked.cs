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
        if (scene.Length > 0)
        {
            if (isLocked == null)
            {
                SceneManager.LoadScene(scene);
            }
            else if (!isLocked.value)
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
