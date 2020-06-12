using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public float moveSpeed;
    public bool canMove = false;
    public bool isKnockback = false;

    public Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if in vicinity of the player, move to the left (y and z stay the same)
        if (canMove)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
        }

        //knock broken
        /*if(canMove && !isKnockback)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f); 
        } 
        else if (isKnockback)
        {
            myRigidbody.velocity = new Vector3(5f, 0f, 0f);
        }*/
    }

    //built in unity function. When something is visible on screen. There is also OnBecameInvisible
    private void OnBecameVisible()
    {
        canMove = true;        
    }

    //destroy enemy if colliding with the Kill Plane
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "KillPlane")
        {
            gameObject.SetActive(false);
        }
    }

    //spider resets to original position when the game resets
    private void OnEnable()
    {
        canMove = false;
    }
}
