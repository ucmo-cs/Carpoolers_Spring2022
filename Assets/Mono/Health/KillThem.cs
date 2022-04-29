using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillThem : MonoBehaviour
{
    public FloatSO playerHealth;

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.value <= 0) {
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
