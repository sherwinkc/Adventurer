using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Skel_Controller : MonoBehaviour
{
    public float moveSpeed;
    public bool canMove = false;
    public bool isKnockback = false;

    public bool movingLeft = true;
    public bool movingRight = false;

    public float timeCount = 0f;
    public float movingTime;

    public Animator animator;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("SpiderHurt"))
        {
            rb.velocity = new Vector3(2f, rb.velocity.y, 0f);
        }
        else if (canMove) //if in vicinity of the player, move to the left (y and z stay the same)
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
        }

        /*if (timeCount <= movingTime)
        {
            timeCount += Time.deltaTime;
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("SpiderHurt"))
            {
                rb.velocity = new Vector3(2f, rb.velocity.y, 0f);
            }
            else if (canMove) //if in vicinity of the player, move to the left (y and z stay the same)
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
            }
        }
        
        if (timeCount > movingTime)
        {
            timeCount = 0f;
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
            //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        /*if(rb.velocity.x <= 0 && movingLeft)
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }*/

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
        if (other.tag == "KillPlane")
        {
            gameObject.SetActive(false);
        }
    }

    //spider resets to original position when the game resets
    private void OnEnable()
    {
        canMove = false;
    }

    void FlipSpider()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
