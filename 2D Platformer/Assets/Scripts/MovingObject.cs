using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public GameObject objectToMove;

    public Transform startPoint;
    public Transform endPoint;

    public float moveSpeed;

    private Vector3 currentTarget;

    //Error when deleted character controller
    //public Player player;
    public BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = endPoint.position;
        //player = FindObjectOfType<PlayerNew>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

        if(objectToMove.transform.position == endPoint.position)
        {
            currentTarget = startPoint.position;
        }

        if(objectToMove.transform.position == startPoint.position)
        {
            currentTarget = endPoint.position;
        }

        //TODO Trying to disable the collider while the player is underneath so the can jump from underneath it.
        /*Debug.Log("player.transform.position.y" + player.transform);
        if(player.transform.position.y <= transform.position.y)
        {
            boxCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled = true;
        }*/
    }
}
