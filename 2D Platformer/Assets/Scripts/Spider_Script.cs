using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Script : MonoBehaviour
{
    //Components
    public Animator animator;
    public PlayerCombat playerCombat;
    public Rigidbody2D rb;
    public SpiderController spiderController;
    public GameObject deathSplosion;
    public GameObject orbsOnDeath;
    public DestroyOverTime destroyOverTime;
    public Upgrades upgrades; //kills add to super amount

    //Enemies
    public SpiderController spider;

    public int maxHealth;
    public int currentHealth;

    //Audio
    public AudioSource enemyGrunt;
    public AudioSource bloodSquelch;

    // Start is called before the first frame update
    void Start()
    {
        //set currentHealth to max health
        currentHealth = maxHealth;

        //Get Components
        animator = GetComponent<Animator>();
        destroyOverTime = GetComponentInParent<DestroyOverTime>();
        spiderController = GetComponent<SpiderController>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();
        spider = FindObjectOfType<SpiderController>();
        rb = GetComponent<Rigidbody2D>();
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
            animator.SetTrigger("Hurt");
            //spider.isKnockback = true;
        }

        if (currentHealth <= 0)
        {
            Die();
            Instantiate(deathSplosion, transform.position, transform.rotation);

            for (int i = 0; i < Random.Range(2f, 4f); i++)
            {
                Instantiate(orbsOnDeath, new Vector2(transform.position.x, transform.position.y + 1), transform.rotation);
            }

            playerCombat.superAmount += upgrades.superAmountReturned; // What is happening here???
        }

        //SFX        
        if (enemyGrunt != null)
        {
            enemyGrunt.Play();
        }

        bloodSquelch.Play(); 
    }

    void Die()
    {
        animator.SetBool("isDead", true);

        spiderController.canMove = false;

        //Disable Rigidbody  
        rb.simulated = false;

        //Disable Circle Collider in Children 
        GetComponentInChildren<CircleCollider2D>().enabled = false;

        //Disable this Spider_Script component
        this.enabled = false;

        //Destroy Parent object over time
        destroyOverTime.isOn = true;
    }
}
