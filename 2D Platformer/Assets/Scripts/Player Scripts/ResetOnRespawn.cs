using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ResetOnRespawn : MonoBehaviour
{
    private Vector3 startPosition, startLocalScale;
    private Quaternion startRotation;

    private Rigidbody2D myRigidbody;
    private Enemy health;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        startLocalScale = transform.localScale;

        //checks if there is a rigidboddy attached to the object. If not ignore.
        if(GetComponent<Rigidbody2D>() != null)
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }
        
        if (GetComponent<Enemy>() != null)
        {
            health = GetComponent<Enemy>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetObject()
    {
        health.currentHealth = GetComponent<Enemy>().maxHealth;
        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.localScale = startLocalScale;

        //if there was velocity movement this gets activated. If it was still it doesn't move
        if (myRigidbody != null)
        {
            myRigidbody.velocity = Vector3.zero; //shorthand for vector3(0f,0f,0f);
                                                    //myRigidbody.velocity = Vector3
        }        
    }
}
