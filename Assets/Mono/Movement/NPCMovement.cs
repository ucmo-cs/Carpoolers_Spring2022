using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    public float speed;
    public NavMeshAgent navAgent;
    public Transform[] points;
    public bool followPlayer = false;


    private int destPoint;
    private bool trackingPlayer;
    private Vector2 velocity;

    void Start()
    {
        if (navAgent == null) navAgent = GetComponent<NavMeshAgent>();
        destPoint = 0;
        navAgent.updateRotation = false;
        navAgent.updateUpAxis = false;
    }

    void FixedUpdate()
    {
        if (followPlayer && DetectPlayer())
        {
            // fetch player's location and update where to go
        }
        else
        {
            if (points.Length != 0 && !navAgent.pathPending && navAgent.remainingDistance < 0.5f)
                Patrol();
        }
    }

    // moves towards point
    void Patrol()
    {
        navAgent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    // Have logic here to see if there is a player present
    bool DetectPlayer()
    {
        return false;
    }
}
