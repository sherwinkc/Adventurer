using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenWiggleController : MonoBehaviour
{
    public Transform leftPoint, rightPoint;

    public float moveSpeed;

    private Rigidbody2D myRigidbody;
    public Animator animator;

    public bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //checking if the enemy is left or right of the left or right point.
        if(movingRight && transform.position.x > rightPoint.position.x)
        {
            movingRight = false;
        }
        if (!movingRight && transform.position.x < leftPoint.position.x)
        {
            movingRight = true;
        }

        //moving right is true or false, move in the opposite direction
        if(movingRight)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("GreenWiggleHit"))
            {
                myRigidbody.velocity = new Vector3(-2f, myRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(3.5f, 3.5f, 1f);
            }
            else
            {
                myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(3.5f, 3.5f, 1f);
            }
        }
        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("GreenWiggleHit"))
            {
                myRigidbody.velocity = new Vector3(2f, myRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(3.5f, 3.5f, 1f);
            }
            else
            {
                myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(-3.5f, 3.5f, 1f);

            }
        }



    }
}
