using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Bird_Script : MonoBehaviour
{
    //Components
    public AIPath aiPath;
    public AIDestinationSetter aiDestSetter;

    public Animator animator;
    public PlayerCombat playerCombat;
    public SpriteRenderer spriteRenderer;
    public Upgrades upgrades;
    public DestroyOverTime destroyOverTime;
    public Bird_Controller birdController;
    public DetectBirds detectBirds;
    //public Rigidbody2D rb;
    //public BoxCollider2D boxCollider2D;

    public GameObject deathSplosion;
    public GameObject orbsOnDeath;

    public int maxHealth;
    public int currentHealth;

    //Audio
    public AudioSource crow, squelch, die;

    void Start()
    {
        currentHealth = maxHealth;

        animator = GetComponent<Animator>();
        destroyOverTime = GetComponent<DestroyOverTime>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        detectBirds = GetComponentInChildren<DetectBirds>();

        //rb = GetComponentInParent<Rigidbody2D>();
        //boxCollider2D = GetComponentInParent<BoxCollider2D>();

        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();

        aiPath = GetComponent<AIPath>();
        aiDestSetter = GetComponent<AIDestinationSetter>();

        birdController = GetComponent<Bird_Controller>();

        spriteRenderer.enabled = true;
        detectBirds.enabled = true;
        //rb.simulated = false;
        //boxCollider2D.enabled = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth >= 0)
        {
            animator.SetTrigger("Hurt");
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
        }

        crow.Play();
        squelch.Play();
    }


    void Die()
    {
        //animator.SetTrigger("Die");
        spriteRenderer.enabled = false;
        detectBirds.enabled = false;

        //Stop/Start Audio
        birdController.crow1.Stop();
        birdController.crow2.Stop();
        die.Play();

        //turn off all pathfinding
        //aiPath.canMove = false;
        aiPath.enabled = false;
        aiDestSetter.enabled = false;
        birdController.enabled = false;

        //Disable Box Colliders
        //GetComponentInChildren<CircleCollider2D>().enabled = false;
        //GetComponent<CircleCollider2D>().enabled = false;

        //rb.simulated = true;
        //boxCollider2D.enabled = true;

        //Destroy Parent object over time
        destroyOverTime.isOn = true;

        //Disable this Enemy Script component
        this.enabled = false;
    }
}
        