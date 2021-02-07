using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float moveSpeed;
    //private float activeMoveSpeed;
    public Rigidbody2D myRigidbody;
    private Animator myAnim;
    public LevelManager theLevelManager;

    //public bool canMove;

    public Vector3 respawnPosition;


    //public float knockbackForce, knockbackLength;
    //private float knockbackCounter;

    //public float invincibilityLength;
    //private float invincibilityCounter;

    //Failing after changing from character controller 2D
    private bool onPlatform;
    public float onPlatformSpeedModifier;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        theLevelManager = FindObjectOfType<LevelManager>();

        respawnPosition = transform.position;
        //canMove = true;

        //activeMoveSpeed = moveSpeed;

    }

    // Update is called once per frame
    void Update()
    {

        //if statement to disable player input during knockback
        //if (knockbackCounter <= 0 && canMove)
        {
            //modify player speed while on the platform
            /*if (onPlatform)
            {
                activeMoveSpeed = moveSpeed * onPlatformSpeedModifier;
            }
            else
            {
                activeMoveSpeed = moveSpeed;
            }

            //Player Input, Right, Left and Jump
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                myRigidbody.velocity = new Vector3(activeMoveSpeed, myRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(10f, 10f, 1f); // Sets the scale of the sprite (facing right when right is pressed). Setting this so we can return to facing right after facing left
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                myRigidbody.velocity = new Vector3(-activeMoveSpeed, myRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(-10f, 10f, 1f); // Inverts the scale of the sprite (facing left when left is pressed)
            }
            else
            {
                myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
            }*/
        }

        //if getting knocked back apply a force
        /*if (knockbackCounter > 0)
        {
            //time it counts down
            knockbackCounter -= Time.deltaTime;
            //if statement to change the direction of the knockback
            if (transform.localScale.x > 0)
            {
                //knock direction - diagonally
                //myRigidbody.velocity = new Vector3(-knockbackForce, knockbackForce, 0f);
                myRigidbody.velocity = new Vector3(-knockbackForce, 0f, 0f);
            }
            else
            {
                //myRigidbody.velocity = new Vector3(knockbackForce, knockbackForce, 0f);
                myRigidbody.velocity = new Vector3(knockbackForce, 0f, 0f);
            }
        }*/

        /*if (invincibilityCounter > 0)
        {
            //invincibility counting down
            invincibilityCounter -= Time.deltaTime;
        }

        if (invincibilityCounter <= 0)
        {
            //at the end of invincibility counter player stop becoming invincible
            theLevelManager.invincible = false;
        }

        myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));*/
        //myAnim.SetBool("Grounded", isGrounded);

        //activate the stomp box trigger only on the way down, when y velocity is a minus value
       /* if (myRigidbody.velocity.y < 0)
        {
            stompBox.SetActive(true);
        }
        else
        {
            stompBox.SetActive(false);
        }*/
    }

    /*public void Knockback()
    {
        knockbackCounter = knockbackLength;
        invincibilityCounter = invincibilityLength;
        //sets the invincibility in the level manager script
        theLevelManager.invincible = true;
    }*/

    // Detect whether the player falls into the Kill Plane box and deactivates (little tick in the Inspector). If dead, player is respawned at the respawnPosition
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            //Debug.Log("KillPlane Triggered");
            //gameObject.SetActive(false);
            //transform.position = respawnPosition;
            //theLevelManager.healthCount = 0;
           theLevelManager.Respawn();
        }

        //Respawn poisiton would be the last checkpoint hit
        if (other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
            //Debug.Log("respawnPosition " + respawnPosition);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
            onPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
            onPlatform = false;
        }
    }
}
