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

    public GameObject squib;
    public GameObject swordSwipeVFX;
    public GameObject deathSplosion;
    public GameObject orbsOnDeath;

    public CircleCollider2D cCollider;

    public int maxHealth;
    public int currentHealth;

    //Audio
    public AudioSource crow, squelch, die;

    void Awake()
    {
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
    }

    void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer.enabled = true;
        detectBirds.enabled = true;
        //rb.simulated = false;
        //boxCollider2D.enabled = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(swordSwipeVFX, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));

        if (currentHealth >= 0)
        {
            animator.SetTrigger("Hurt");
            Instantiate(squib, transform.position, transform.rotation);
        }

        if (currentHealth <= 0)
        {
            //turn off pathfinding && colliders here - will crash otherwise
            cCollider.enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponentInChildren<CircleCollider2D>().enabled = false;
            GetComponentInChildren<BoxCollider2D>().enabled = false;

            aiPath.canMove = false;
            aiPath.enabled = false;
            aiDestSetter.enabled = false;
            birdController.enabled = false;

            Instantiate(deathSplosion, transform.position, transform.rotation);

            for (int i = 0; i < Random.Range(1f, 5f); i++)
            {
                Instantiate(orbsOnDeath, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            }

            playerCombat.superAmount += upgrades.superAmountReturned;

            Die();
        }

        crow.pitch = Random.Range(0.95f, 1.05f);
        crow.Play();
        squelch.pitch = Random.Range(0.95f, 1.05f);
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
        aiPath.canMove = false;
        aiPath.enabled = false;
        aiDestSetter.enabled = false;
        birdController.enabled = false;

        //Disable Colliders
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponentInChildren<CircleCollider2D>().enabled = false;
        GetComponentInChildren<BoxCollider2D>().enabled = false;

        //rb.simulated = true;
        //boxCollider2D.enabled = true;

        //Destroy Parent object over time
        destroyOverTime.isOn = true;

        //Disable this Enemy Script component
        this.enabled = false;
    }
}
        
