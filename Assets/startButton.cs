using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : MonoBehaviour
{
    public StartGame game;
    void Update()
    {
        //Debug.Log("StartButton");
        if (Input.GetKeyDown("return")){
            game.loadLevel();
        }
    }
}
