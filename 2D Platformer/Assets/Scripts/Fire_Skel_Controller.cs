using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Skel_Controller : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public PlayerMovement playerMovement;
    public LevelManager levelManager;

    public float moveSpeed;
    public bool canMove = false;

    public bool attacking = false;

    public float attackCooldown;
    public float attackCounter;
    public bool startCooldown = false;

    public float distanceToPlayer;


    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the player
        
        if(levelManager.healthCount > 0 )
        {
            if (playerMovement.transform.position.x < transform.position.x && canMove && !attacking)
            {
                rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
                transform.localScale = new Vector3(3, transform.localScale.y, transform.localScale.y);
            }
            else if (playerMovement.transform.position.x > transform.position.x && canMove && !attacking )
            {
                rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
                transform.localScale = new Vector3(-3, transform.localScale.y, transform.localScale.y);
            }
            else
            {
                rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.y);
            }
        }
  
        if (Vector2.Distance(transform.position, playerMovement.transform.position) < distanceToPlayer && attackCounter <= 0)
        {
            if(levelManager.healthCount > 0)
            {
                if (playerMovement.transform.position.x < transform.position.x)      
                {
                    animator.SetTrigger("Attack1");
                    startCooldown = true;
                }
                else if (playerMovement.transform.position.x > transform.position.x)
                {
                    animator.SetTrigger("Attack1");
                    startCooldown = true;
                }
            }
        }

        if (attackCounter >= attackCooldown)
        {
            attackCounter = 0f;
            startCooldown = false;
        }

        if (startCooldown)
        {
            attackCounter += Time.deltaTime;
        }

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }
    }

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
}
