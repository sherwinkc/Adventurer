using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sludge_Script : MonoBehaviour
{
    //Components
    public Animator animator;
    public PlayerCombat playerCombat;
    public Rigidbody2D rb;
    public Sludge_Controller sludgeController;

    public GameObject deathSplosion;
    public GameObject orbsOnDeath;
    public DestroyOverTime destroyOverTime;
    public Upgrades upgrades; //kills add to super amount

    public int maxHealth;
    public int currentHealth;

    //Audio
    public AudioSource grunt;    

    void Start()
    {
        //set currentHealth to max health
        currentHealth = maxHealth;

        //Get Components
        animator = GetComponent<Animator>();
        destroyOverTime = GetComponentInParent<DestroyOverTime>();
        rb = GetComponent<Rigidbody2D>();
        sludgeController = GetComponent<Sludge_Controller>();

        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();
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
        }

        if (currentHealth <= 0)
        {
            Die();
            Instantiate(deathSplosion, transform.position, transform.rotation);

            for (int i = 0; i < Random.Range(2f, 4f); i++)
            {
                Instantiate(orbsOnDeath, new Vector2(transform.position.x, transform.position.y + 1), transform.rotation);
            }

            playerCombat.superAmount += upgrades.superAmountReturned; // returns the upgraded amount of super energy
        }

        //SFX        
        if (grunt != null)
        {
            grunt.Play();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);

        //Disable Rigidbody
        rb.simulated = false;

        //Disable Circle Collider
        GetComponent<CircleCollider2D>().enabled = false;

        //Disable this Spider_Script component
        this.enabled = false;

        //Destroy Parent object over time
        destroyOverTime.isOn = true;
    }
}
