using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Bird_Controller : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement playerMovement;

    public AIPath aiPath;

    public Rigidbody2D rb;
    //public LevelManager levelManager;

    public float flySpeed;

    //public bool attacking = false;
    //public bool guarding = false;

    public float attackCooldown;
    public float attackCounter;
    public bool startCooldown = false;

    public float farDistanceToPlayer;
    public float distanceToPlayer;
    public float attackDistance;

    public bool canMoveAndAttack = true;

    public AudioSource crow1, crow2, flap;

    void Start()
    {
        animator = GetComponent<Animator>();
        aiPath = GetComponent<AIPath>();
        //rb = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();

        aiPath.maxSpeed = flySpeed;
        aiPath.canMove = false;

        attackCounter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.y);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.y);
        }

        //fly fast and move player if within distance
        
        if (canMoveAndAttack)// can fly and attack during locked door
        {
            if (Vector2.Distance(transform.position, playerMovement.transform.position) < farDistanceToPlayer && Vector2.Distance(transform.position, playerMovement.transform.position) > distanceToPlayer)
            {
                aiPath.canMove = true;
                aiPath.maxSpeed = flySpeed * 2f;
                animator.SetTrigger("FlyFaster");
                if(!crow2.isPlaying)
                {
                    crow2.pitch = Random.Range(0.85f, 1f);
                    crow2.Play();
                }
            } 
            else if (Vector2.Distance(transform.position, playerMovement.transform.position) < distanceToPlayer)
            {
                aiPath.canMove = true;
                aiPath.maxSpeed = flySpeed;
                animator.SetTrigger("FlySlower");
            }

            //attack if within distance
            if (Vector2.Distance(transform.position, playerMovement.transform.position) < attackDistance && attackCounter <= 0)
            {
                animator.SetTrigger("Attack");
                startCooldown = true;
            }
        }        

        if(!canMoveAndAttack)
        {
            aiPath.canMove = false;
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

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            aiPath.maxSpeed = 0f;
        }
    }

    public void FlapSFX()
    {
        if(Vector2.Distance(transform.position, playerMovement.transform.position) < farDistanceToPlayer)
        {
            if(!flap.isPlaying)
            {
                flap.pitch = (Random.Range(0.75f, 2f));
                flap.Play();
            }
        }
    }

    public void BirdAttackSFX()
    {
        if (Vector2.Distance(transform.position, playerMovement.transform.position) < farDistanceToPlayer)
        {
            if(!crow1.isPlaying)
            {
                crow2.Stop();
                crow1.pitch = (Random.Range(0.9f, 1f));
                crow1.Play();
            }
        }
    }
}
