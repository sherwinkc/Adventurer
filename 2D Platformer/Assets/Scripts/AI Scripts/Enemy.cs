using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Components
    public Rigidbody2D rb;
    public Animator animator;
    public Enemy_Behaviour enemyBehaviour;
    public PlayerCombat playerCombat;
    public Upgrades upgrades;
    public DestroyOverTime destroyOverTime;
    
    public GameObject deathSplosion;
    public GameObject orbsOnDeath;

    public int maxHealth;
    public int currentHealth;

    //Audio
    public AudioSource enemyGrunt1, bloodSquelch, die;

    void Start()
    {
        currentHealth = maxHealth;

        enemyBehaviour = GetComponent<Enemy_Behaviour>();
        destroyOverTime = GetComponentInParent<DestroyOverTime>();
        rb = GetComponent<Rigidbody2D>();

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

        enemyGrunt1.Play();
        bloodSquelch.Play();

        if (currentHealth <= 0)
        {
            enemyBehaviour.idle.Stop();

            Instantiate(deathSplosion, transform.position, transform.rotation);

            for (int i = 0; i < Random.Range(4f, 5f); i++)
            {
                Instantiate(orbsOnDeath, new Vector2(transform.position.x, transform.position.y), transform.rotation);
            }

            Die();

            playerCombat.superAmount += upgrades.superAmountReturned; //???

        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);

        die.Play();

        rb.simulated = false;
        enemyBehaviour.enabled = false;
        
        //Disable Box Colliders
        GetComponentInChildren<BoxCollider2D>().enabled = false;

        //Disable any circle collders
        GetComponentInChildren<CircleCollider2D>().enabled = false;

        //Destroy Parent object over time
        destroyOverTime.isOn = true;

        //Disable this Enemy Script component
        this.enabled = false;
    }
}
