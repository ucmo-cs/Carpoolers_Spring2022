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
    public BoolSO hasElectricSword;

    private int destPoint;
    private bool trackingPlayer = false;
    private Vector2 velocity;
    private GameObject player;

    void Start()
    {
        if (navAgent == null) navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        destPoint = 0;
        navAgent.updateRotation = false;
        navAgent.updateUpAxis = false;
    }

    void FixedUpdate()
    {
        if (hasElectricSword);
        {
            if (followPlayer && trackingPlayer)
            {
                FollowPlayer();
                // fetch player's location and update where to go
            }
            else
            {
                if (points.Length != 0 && !navAgent.pathPending && navAgent.remainingDistance < 0.5f)
                    Patrol();
            }
        }
    }

    // moves towards point
    void Patrol()
    {
        navAgent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    void FollowPlayer() {
        navAgent.destination = player.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            trackingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            trackingPlayer = false;
        }
    }
}
