using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public PlayerMovement playerMovement;

    public float moveSpeed;
    public bool canMove = false;
    public bool isKnockback = false;

    public AudioSource churp, scurry;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.transform.position.x < transform.position.x && canMove)
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
            transform.localScale = new Vector3(-2f, transform.localScale.y, transform.localScale.y);
        }
        else if (playerMovement.transform.position.x > transform.position.x && canMove)
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
            transform.localScale = new Vector3(2f, transform.localScale.y, transform.localScale.y);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("SpiderHurt")) // if spider is hurt he is pushed back - interesting
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
            //scurry.Stop();
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
        churp.Play();
        scurry.Play();
    }

    //destroy enemy if colliding with the Kill Plane
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            gameObject.SetActive(false);
        }

        if (other.tag == "Player")
        {
            if(!churp.isPlaying)
            {                
                churp.Play();
            }
        }

    }

    //spider resets to original position when the game resets
    private void OnEnable()
    {
        canMove = false;
    }
}
