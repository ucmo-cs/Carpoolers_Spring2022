using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string levelName;
    public StringSO playerSpawnTag;
    public Vector2SO playerSpawnOffset;

    public List<BoolSO> setToFalse;
    public List<BoolSO> setToTrue;
    public List<StringListSO> setToEmpty;
    public FloatSO health;
    public FloatSO maxHealth;

    public void loadLevel(){
        playerSpawnTag.value = "Exit Door";
        playerSpawnOffset.value = new Vector2(0, 1);

        foreach (BoolSO value in setToFalse) value.value = false;
        foreach (BoolSO value in setToTrue) value.value = true;
        foreach (StringListSO value in setToEmpty) value.value = new List<string>();

        health.value = maxHealth.value;

        SceneManager.LoadScene(levelName);
    }
}
