using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_Bird_Script : MonoBehaviour
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
    public AudioSource enemyGrunt1;
    public AudioSource bloodSquelch;

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

        if (enemyGrunt1 != null)
        {
            enemyGrunt1.Play();
        }

        bloodSquelch.Play();

        if (currentHealth <= 0)
        {
            Die();
            Instantiate(deathSplosion, transform.position, transform.rotation);

            for (int i = 0; i < Random.Range(2f, 4f); i++)
            {
                Instantiate(orbsOnDeath, new Vector2(transform.position.x, transform.position.y + 1), transform.rotation);
            }

            playerCombat.superAmount += upgrades.superAmountReturned; //???
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);

        //Disable Enemy Behaviour on parent
        if (GetComponentInParent<Enemy_Behaviour>() != null)
        {
            GetComponentInParent<Enemy_Behaviour>().enabled = false;
        }

        if (GetComponentInParent<EnemyBehaviour_Still>() != null)
        {
            GetComponentInParent<EnemyBehaviour_Still>().enabled = false;
        }

        //Disable Rigidbody on Parent        
        if (GetComponentInParent<Rigidbody2D>() != null)
        {
            GetComponentInParent<Rigidbody2D>().simulated = false;
        }

        //Disable Box Colliders
        if (GetComponent<BoxCollider2D>() != null)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }

        //Disable any circle collders
        if (GetComponent<CircleCollider2D>() != null)
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }

        if (GetComponentInParent<CircleCollider2D>() != null)
        {
            GetComponentInParent<CircleCollider2D>().enabled = false;
        }

        //Disable Bird script in parent
        if (GetComponentInParent<BirdGFX>() != null)
        {
            GetComponentInParent<BirdGFX>().enabled = false;
        }
        if (GetComponentInParent<AIPath>() != null)
        {
            GetComponentInParent<AIPath>().enabled = false;
        }
        if (GetComponentInParent<Seeker>() != null)
        {
            GetComponentInParent<Seeker>().enabled = false;
        }
        if (GetComponentInParent<AIDestinationSetter>() != null)
        {
            GetComponentInParent<AIDestinationSetter>().enabled = false;
        }

        //Destroy Parent object over time
        destroyOverTime.isOn = true;

        //Disable this Enemy Script component
        this.enabled = false;
    }
}
