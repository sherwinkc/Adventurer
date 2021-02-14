using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BirdGFX : MonoBehaviour
{
    //Components
    public AIPath aiPath;
    public AIDestinationSetter aiDestSetter;

    public Animator animator;
    public Rigidbody2D rb;
    public PlayerCombat playerCombat;
    public Upgrades upgrades;
    public DestroyOverTime destroyOverTime;
    public BoxCollider2D boxCollider2D;
    public Bird_Controller birdController;

    public GameObject deathSplosion;
    public GameObject orbsOnDeath;

    public int maxHealth;
    public int currentHealth;

    //Audio
    //public AudioSource enemyGrunt1;
    //public AudioSource bloodSquelch;

    void Start()
    {
        currentHealth = maxHealth;

        animator = GetComponent<Animator>();
        destroyOverTime = GetComponent<DestroyOverTime>();

        rb = GetComponentInParent<Rigidbody2D>();
        boxCollider2D = GetComponentInParent<BoxCollider2D>();

        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();

        aiPath = GetComponent<AIPath>();
        aiDestSetter = GetComponent<AIDestinationSetter>();

        birdController = GetComponent<Bird_Controller>();

        //rb.simulated = false;
        boxCollider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth >= 0)
        {
            //animator.SetTrigger("Hurt");
        }

        if (currentHealth <= 0)
        {
            Instantiate(deathSplosion, transform.position, transform.rotation);

            for (int i = 0; i < Random.Range(4f, 5f); i++)
            {
                Instantiate(orbsOnDeath, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            }

            Die();
            playerCombat.superAmount += upgrades.superAmountReturned;

            /*if (enemyGrunt1 != null)
            {
                enemyGrunt1.Play();
            }

            bloodSquelch.Play();
            }*/
        }

        void Die()
        {
            animator.SetTrigger("Die");

            //turn off all pathfinding
            //aiPath.canMove = false;
            aiPath.enabled = false;
            aiDestSetter.enabled = false;
            birdController.enabled = false;
            
            //Disable Box Colliders
            GetComponentInChildren<CircleCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            rb.simulated = true;
            boxCollider2D.enabled = true;


            //Destroy Parent object over time
            destroyOverTime.isOn = true;

            //Disable this Enemy Script component
            this.enabled = false;
        }
    }
}
