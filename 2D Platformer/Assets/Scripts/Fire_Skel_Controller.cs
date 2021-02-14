using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Skel_Controller : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public PlayerMovement playerMovement;
    public LevelManager levelManager;
    public Fire_Skel_Script fireSkelScript;

    public float moveSpeed;
    public bool canMove = false;

    public bool attacking = false;
    public bool guarding = false;

    public float attackCooldown;
    public float attackCounter;
    public bool startCooldown = false;

    public float distanceToPlayer;

    //choose a state/anim
    string state;
    string[] stateList = { "Attack1", "Guard" };

    //Audio
    public AudioSource swipe, idle, skel_steps;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
        fireSkelScript = GetComponent<Fire_Skel_Script>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        levelManager = FindObjectOfType<LevelManager>();        
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the player
        if (playerMovement.transform.position.x < transform.position.x && canMove && !attacking && levelManager.healthCount > 0 && !guarding )
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
            transform.localScale = new Vector3(3, transform.localScale.y, transform.localScale.y);
        }
        else if (playerMovement.transform.position.x > transform.position.x && canMove && !attacking && levelManager.healthCount > 0 && !guarding)
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
            transform.localScale = new Vector3(-3, transform.localScale.y, transform.localScale.y);
        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.y);
            animator.SetTrigger("Idle");
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyHurt")) // TODO: if Bandit is hurt he is pushed back
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }  

        // check if player is in close proximity and either attack or guard
        if (Vector2.Distance(transform.position, playerMovement.transform.position) < distanceToPlayer && attackCounter <= 0 && canMove)
        {
            if (levelManager.healthCount > 0)
            {
                state = stateList[Random.Range(0, stateList.Length)];
                animator.SetTrigger(state);
                startCooldown = true;
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

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Guard"))
        {
            guarding = true;
        }
        else
        {
            guarding = false;
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

    }

    private void OnBecameVisible()
    {
        canMove = true;
        idle.Play();
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

    public void Skel_SwipeSFX()
    {
        swipe.Play();
    }

    public void Skel_FootstepSFX()
    {        
        skel_steps.pitch = (Random.Range(0.7f, 1.2f));
        skel_steps.Play();
    }
}
