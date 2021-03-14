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
    
    public Transform squibTransform;
    public GameObject squib;
    public GameObject swordSwipeVFX;
    public GameObject deathSplosion;
    public GameObject orbsOnDeath;

    public int maxHealth;
    public int currentHealth;

    //Audio
    public AudioSource enemyGrunt1, grunt2, bloodSquelch, die;

    void Awake()
    {
        enemyBehaviour = GetComponent<Enemy_Behaviour>();
        destroyOverTime = GetComponentInParent<DestroyOverTime>();
        rb = GetComponent<Rigidbody2D>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(swordSwipeVFX, squibTransform.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));

        if (currentHealth >= 0)
        {
            animator.SetTrigger("Hurt");
            Instantiate(squib, squibTransform.transform.position, squibTransform.transform.rotation);
            grunt2.Play();
        } 

        enemyGrunt1.pitch = Random.Range(0.9f, 1.1f);
        enemyGrunt1.Play();
        bloodSquelch.pitch = Random.Range(0.9f, 1.1f);
        bloodSquelch.Play();

        if (currentHealth <= 0)
        {
            enemyBehaviour.idle.Stop();

            Instantiate(deathSplosion, squibTransform.transform.position, squibTransform.transform.rotation);

            for (int i = 0; i < Random.Range(2f, 6f); i++)
            {
                Instantiate(orbsOnDeath, new Vector2(squibTransform.transform.position.x, squibTransform.transform.position.y), squibTransform.transform.rotation);
            }

            Die();

            playerCombat.superAmount += upgrades.superAmountReturned;

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
