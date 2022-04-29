using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneIfUnlocked : MonoBehaviour
{
    public BoolSO isLocked;
    public string scene;
    public string newPlayerSpawnTag;
    public StringSO playerSpawnTag;
    public Vector2 newPlayerSpawnOffset;
    public Vector2SO playerSpawnOffset;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Player" && scene.Length > 0 && (isLocked == null || !isLocked.value))
        {
            playerSpawnTag.value = newPlayerSpawnTag;
            playerSpawnOffset.value = newPlayerSpawnOffset;
            SceneManager.LoadScene(scene);
        }
    }
}
