using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string levelName;
    public StringSO playerSpawnTag;
    public Vector2SO playerSpawnOffset;

    public void loadLevel(){
        Debug.Log("hi");
        playerSpawnTag.value = "Exit Door";
        playerSpawnOffset.value = new Vector2(0, 1);
        SceneManager.LoadScene(levelName);
    }
}
