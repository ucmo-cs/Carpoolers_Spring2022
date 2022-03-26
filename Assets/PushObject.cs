using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    // how many times can an item be pushed (set to -1 to infinitely push)
    public int pushCount = 0;
    // detect when collided with player and increment or decrement .transform by 1 for X or Y
    public DirectionSO playerDirection = null;
    public float rawMovementSpeed = 1.0f;

    private GameObject moveableObject;

    // Start is called before the first frame update
    void Start()
    {
        if (!playerDirection)
        {
            // get player direction through cody code
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // do math to send it up down left or right
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        // Debug.Log(collisionInfo.getDirection);
        if (collisionInfo.gameObject.tag == "Player")
        {
            if (pushCount > 0)
            {
                pushCount--;
                pushInDirection();
            }
            else if (pushCount == -1)
            {
                pushInDirection();
            }
        }
    }

    void pushInDirection()
    {
        Debug.Log(playerDirection.value);
        System.Console.WriteLine(playerDirection.value);
        float movementSpeed = rawMovementSpeed * Time.deltaTime;
        Vector3 endpoint;
        switch (playerDirection.value)
        {
            case Direction.EAST:
                endpoint = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                Debug.Log(endpoint);
                Debug.Log(transform.position);
                transform.position = endpoint;
                // transform.position = Vector3.Lerp(transform.position, endpoint, movementSpeed);
                break;
            case Direction.WEST:
                endpoint = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                Debug.Log(endpoint);
                Debug.Log(transform.position);
                transform.position = endpoint;
                break;
            case Direction.NORTH:
                endpoint = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                Debug.Log(endpoint);
                Debug.Log(transform.position);
                transform.position = endpoint;
                break;
            case Direction.SOUTH:
                endpoint = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                Debug.Log(endpoint);
                Debug.Log(transform.position);
                transform.position = endpoint;
                break;
            default:
                Debug.Log("What the hell");
                break;
        }

    }
}
