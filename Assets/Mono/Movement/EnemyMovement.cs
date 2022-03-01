using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public NavMeshAgent navAgent;
    public Transform[] points;


    private int destPoint;
    private bool trackingPlayer;
    private Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        if (navAgent == null)
        {
            navAgent = GetComponent<NavMeshAgent>();
        }
        destPoint = 0;
        navAgent.updateRotation = false;
        navAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        // deciding how the enemy should move
        // if (!DetectPlayer())
        // {
        //     Patrol();
        // }
        // else
        // {
        //     // MoveTowardsPlayer();
        // }

    }

    void FixedUpdate()
    {
        if (!DetectPlayer())
        {
            if (points.Length != 0 && !navAgent.pathPending && navAgent.remainingDistance < 0.5f)
                Patrol();
        }
        else
        {

        }
        // making the enemy move or stay put.
        // rigidbody2.velocity = velocity;
    }

    // moves towards point
    void Patrol()
    {
        navAgent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
        // transform.position = Vector2.MoveTowards(transform.position, positions[indead], )
    }

    // Have logic here to see if there is a player present
    bool DetectPlayer()
    {
        return false;
    }
}
