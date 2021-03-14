using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public LevelManager theLevelManager;
    private Animator myAnim;

    public Vector3 respawnPosition;

    //private bool onPlatform; // ??
    public float onPlatformSpeedModifier;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        theLevelManager = FindObjectOfType<LevelManager>();

        respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            theLevelManager.Respawn();
        }

        //Respawn poisiton would be the last checkpoint hit
        if (other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
            //Debug.Log("Hit Checkpoint");
            //Debug.Log(respawnPosition);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
            //onPlatform = true; // ??
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            if(transform.parent)
            {
                transform.parent = null;
                //onPlatform = false; // ??
            }
        }
    }
}
