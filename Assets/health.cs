using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int currHealth = 0;
    public int maxHealth = 3;

    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            DamagePlayer(1);
        }
    }

    public void DamagePlayer (int damage){
        currHealth -= damage;

        healthbar.SetHealth( currHealth );
    }
}
