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

    public Transform squibTransform;
    public GameObject squib;
    public GameObject swordSwipeVFX;

    //Enemies
    public SpiderController spider;

    public int maxHealth;
    public int currentHealth;

    //Audio
    public AudioSource enemyGrunt, bloodSquelch;

    void Awake()
    {
        //Get Components
        animator = GetComponent<Animator>();
        destroyOverTime = GetComponentInParent<DestroyOverTime>();
        spiderController = GetComponent<SpiderController>();
        playerCombat = FindObjectOfType<PlayerCombat>();
        upgrades = FindObjectOfType<Upgrades>();
        spider = FindObjectOfType<SpiderController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //set currentHealth to max health
        currentHealth = maxHealth;
    }

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
        }

        if (currentHealth <= 0)
        {
            Die();
            Instantiate(deathSplosion, squibTransform.transform.position, squibTransform.transform.rotation);

            for (int i = 0; i < Random.Range(1f, 5f); i++)
            {
                Instantiate(orbsOnDeath, new Vector2(squibTransform.transform.position.x, squibTransform.transform.position.y + 1), squibTransform.transform.rotation);
            }

            playerCombat.superAmount += upgrades.superAmountReturned; // What is happening here???
        }

        //SFX        
        if (enemyGrunt != null)
        {
            enemyGrunt.pitch = Random.Range(0.95f, 1.05f);
            enemyGrunt.Play();
        }
        bloodSquelch.pitch = Random.Range(0.95f, 1.05f);
        bloodSquelch.Play();
    }

    void Die()
    {

        animator.SetBool("isDead", true);
        spiderController.churp.Stop();
        spiderController.scurry.Stop();

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
